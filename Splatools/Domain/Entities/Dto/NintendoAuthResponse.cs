using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class NintendoAuthResponse
{
    [JsonProperty("auth_url")] public string AuthUrl { get; set; }

    [JsonProperty("key")] public string Key { get; set; }
}