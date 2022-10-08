using System;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Splatools.Domain.Entities.ValueObjects;

namespace Splatools.Infrastructure.ExternalServices.F;

public class FClient : IFClient
{
    private static HttpClient _client;

    public FClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<FResponse> GetF(string token)
    {
        dynamic param = new ExpandoObject();
        param.token = token;
        param.hash_method = 1;

        var req = new HttpRequestMessage()
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(SplatoonConstants.FEndpoint)
        };

        var content = JsonConvert.SerializeObject(param);
        req.Content = new StringContent(content, Encoding.UTF8, "application/json");
        req.Headers.Add("User-Agent", $"{SplatoonConstants.UserAgent}/{SplatoonConstants.AppVersion}");
        var response = await _client.SendAsync(req);
        var responseBody = await response.Content.ReadAsStringAsync();
        var responseObj = JsonConvert.DeserializeObject<FResponse>(responseBody);
        return responseObj;
    }
}