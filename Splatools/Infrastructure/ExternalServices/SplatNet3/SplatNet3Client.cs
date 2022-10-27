using System;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Splatools.Domain.Entities.ValueObjects;
using Splatools.Infrastructure.ExternalServices.SplatNet3.Models;

namespace Splatools.Infrastructure.ExternalServices.SplatNet3;

public class SplatNet3Client : ISplatNet3Client
{
    private static HttpClient _client;

    public SplatNet3Client(HttpClient client)
    {
        _client = client;
        _client.DefaultRequestHeaders.Add("X-Web-View-Ver", SplatNet3Constants.XWebViewVer);
        _client.DefaultRequestHeaders.Add("Accept-Language", "ja-JP");
    }

    public async Task<ScheduleResponse> GetSchedule(string bulletToken)
    {
        var req = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(SplatNet3Constants.GraphQLEndpoint),
            Content = GetRequest(SplatNet3Constants.GetScheduleHash)
        };
        req.Headers.Add("Authorization", $"Bearer {bulletToken}");
        var response = await _client.SendAsync(req);
        var responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ScheduleResponse>(responseBody);
    }

    private StringContent GetRequest(string hash)
    {
        var req = new GraphQLRequest
        {
            Variables = new Variables(),
            Extensions = new Extensions
            {
                PersistedQuery = new PersistedQuery
                {
                    Sha256Hash = hash,
                    Version = 1
                }
            }
        };

        return new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
    }
}