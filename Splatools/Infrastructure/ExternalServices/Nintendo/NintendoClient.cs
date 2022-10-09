using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Splatools.Domain.Entities.ValueObjects;

namespace Splatools.Infrastructure.ExternalServices.Nintendo;

public class NintendoClient : INintendoClient
{
    private static HttpClient _client;

    public NintendoClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<MeResponse> GetMe(string accessToken)
    {
        var req = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(NintendoConstants.NintendoUsersMeEndpoint)
        };
        req.Headers.Add("Authorization", $"Bearer {accessToken}");
        var response = await _client.SendAsync(req);
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<MeResponse>(responseBody);
    }
}