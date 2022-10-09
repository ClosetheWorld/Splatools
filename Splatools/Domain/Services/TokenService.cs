using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Splatools.Domain.Entities.Dto;
using Splatools.Domain.Entities.ValueObjects;
using Splatools.Domain.Services.Interfaces;
using Splatools.Infrastructure.ExternalServices.F;
using Splatools.Infrastructure.ExternalServices.Nintendo;
using Splatools.Repository.Interfaces;

namespace Splatools.Domain.Services;

public class TokenService : ITokenService
{
    private readonly IAuthenticationParameterRepository _authentication;
    private readonly HttpClient _client;
    private readonly IFClient _fClient;
    private readonly INintendoClient _nintendoClient;

    public TokenService(IAuthenticationParameterRepository authentication, IFClient fClient, HttpClient client,
        INintendoClient nintendoClient)
    {
        _authentication = authentication;
        _fClient = fClient;
        _client = client;
        _nintendoClient = nintendoClient;
    }

    public async Task GetSplatoken(GetSplatokenRequest req)
    {
        // get session token code from request
        var queries = req.Uri.Split('&');
        var sessionTokenCode = queries[1].Substring(19, queries[1].Length - 19);

        // get session token from nintendo api
        var verifier = await CallGetAuthenticationParameter(req.Key);
        var sessionToken = await GetSessionToken(sessionTokenCode, verifier);

        // get access token from nintendo api
        var accessToken = await GetAccessToken(sessionToken.SessionToken);

        // call users/me
        var me = await CallNintendoMe(accessToken.AccessToken);

        // get nso access token from nintendo api
        var f = await CallFApiNsO(accessToken.IdToken);
        var nsoAccessToken = await GetNsoAccessToken(accessToken.IdToken, f, me.Birthday);

        // get game app access token
        f = await CallFApiWebApp(nsoAccessToken.Result.WebApiServerCredential.AccessToken);
        var nsoAppToken = await GetNsoAppAccessToken(nsoAccessToken.Result.WebApiServerCredential.AccessToken, f);

        // get bullet token
        var bulletToken = await GetBulletToken(nsoAppToken.Result.AccessToken);
        
        // TODO: what to do next
    }

    // TODO: error handling
    private async Task<NintendoSessionTokenResponse> GetSessionToken(string sessionTokenCode, string verifier)
    {
        var param = new List<KeyValuePair<string, string>>();
        param.Add(new KeyValuePair<string, string>("client_id", NintendoConstants.NintendoClientId));
        param.Add(new KeyValuePair<string, string>("session_token_code", sessionTokenCode));
        param.Add(new KeyValuePair<string, string>("session_token_code_verifier", verifier));

        var req = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(NintendoConstants.NintendoSessionTokenEndpoint),
            Content = new FormUrlEncodedContent(param)
        };
        req.Headers.Add("Accept", "application/json");

        var response = await _client.SendAsync(req);
        return JsonConvert.DeserializeObject<NintendoSessionTokenResponse>(await response.Content.ReadAsStringAsync());
    }

    // TODO: error handling
    private async Task<NintendoAccessTokenResponse> GetAccessToken(string sessionToken)
    {
        var param = new NintendoAccessTokenRequest
        {
            SessionToken = sessionToken
        };

        var req = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(NintendoConstants.NintendoAccessTokenEndpoint),
            Content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json")
        };
        var response = await _client.SendAsync(req);
        return JsonConvert.DeserializeObject<NintendoAccessTokenResponse>(await response.Content.ReadAsStringAsync());
    }

    // TODO: error handling
    private async Task<NintendoSwitchOnlineTokenResponse> GetNsoAccessToken(string idToken, FResponse f, string birthday)
    {
        var param = new NintendoSwitchOnlineTokenRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            Parameter = new NsoTokenParams
            {
                F = f.F,
                NaBirthDay = birthday,
                NaIdToken = idToken,
                RequestId = f.RequestId,
                TimeStamp = f.TimeStamp
            }
        };

        var req = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(NintendoConstants.NintendoAppTokenEndpoint),
            Content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json")
        };
        req.Headers.Add("Accept", "application/json");
        req.Headers.Add("Accept-Encoding", "ja-JP;q=1.0, en-JP;q=0.9");
        req.Headers.Add("User-Agent", $"{NintendoConstants.NintendoNsOnlineAppUserAgent}");
        req.Headers.Add("X-ProductVersion", "2.3.1");
        req.Headers.Add("X-Platform", "iOS");

        var response = await _client.SendAsync(req);
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<NintendoSwitchOnlineTokenResponse>(responseBody);
    }

    // TODO: error handling
    private async Task<Splatoon3TokenResponse> GetNsoAppAccessToken(string accessToken, FResponse f)
    {
        var param = new Splatoon3TokenRequest
        {
            RequestId = Guid.NewGuid().ToString(),
            Parameter = new Splat3TokenParams
            {
                F = f.F,
                RequestId = f.RequestId,
                RegistrationToken = SplatoonConstants.RegistrationToken,
                Id = SplatoonConstants.Splatoon3ParameterId,
                TimeStamp = f.TimeStamp
            }
        };

        var req = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(NintendoConstants.NintendoNsOnlineTokenEndpoint),
            Content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json")
        };
        req.Headers.Add("Accept", "application/json");
        req.Headers.Add("Accept-Encoding", "ja-JP;q=1.0, en-JP;q=0.9");
        req.Headers.Add("User-Agent", $"{NintendoConstants.NintendoNsOnlineAppUserAgent}");
        req.Headers.Add("X-ProductVersion", "2.3.1");
        req.Headers.Add("X-Platform", "iOS");
        req.Headers.Add("Authorization", $"Bearer {accessToken}");

        var response = await _client.SendAsync(req);
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Splatoon3TokenResponse>(responseBody);
    }

    // TODO: error handling
    private async Task<BulletTokenResponse> GetBulletToken(string nsoAppToken)
    {
        var req = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(SplatoonConstants.Splatoon3BulletTokenEndpoint),
        };
        req.Headers.Add("Cookie", $"_gtoken={nsoAppToken}");
        req.Headers.Add("X-NACOUNTRY", "JP");
        req.Headers.Add("Origin", "https://api.lp1.av5ja.srv.nintendo.net"); // TODO: move to constants
        req.Headers.Add("X-Requested-With", "com.nintendo.znca"); // TODO: move to constants
        req.Headers.Add("X-Web-View-Ver", "1.0.0-216d0219");

        var response = await _client.SendAsync(req);
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<BulletTokenResponse>(responseBody);
    }
    
    private async Task<string> CallGetAuthenticationParameter(string key)
    {
        var guid = new Guid(key);
        return await _authentication.GetSessionTokenCodeVerifier(guid);
    }

    private async Task<FResponse> CallFApiNsO(string sessionTokenCode)
    {
        return await _fClient.GetFForNsO(sessionTokenCode);
    }

    private async Task<FResponse> CallFApiWebApp(string token)
    {
        return await _fClient.GetFForWebApp(token);
    }

    private async Task<MeResponse> CallNintendoMe(string accessToken)
    {
        return await _nintendoClient.GetMe(accessToken);
    }
}