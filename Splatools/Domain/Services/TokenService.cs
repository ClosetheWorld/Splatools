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
using Splatools.Repository.Interfaces;

namespace Splatools.Domain.Services;

public class TokenService : ITokenService
{
    private readonly IAuthenticationParameterRepository _authentication;
    private readonly HttpClient _client;
    private readonly IFClient _fClient;

    public TokenService(IAuthenticationParameterRepository authentication, IFClient fClient, HttpClient client)
    {
        _authentication = authentication;
        _fClient = fClient;
        _client = client;
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

        var f = await CallFApi(sessionTokenCode);
    }

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

    private async Task<string> CallGetAuthenticationParameter(string key)
    {
        var guid = new Guid(key);
        return await _authentication.GetSessionTokenCodeVerifier(guid);
    }

    private async Task<FResponse> CallFApi(string sessionTokenCode)
    {
        return await _fClient.GetF(sessionTokenCode);
    }
}