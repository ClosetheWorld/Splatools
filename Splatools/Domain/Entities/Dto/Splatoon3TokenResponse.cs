using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class Splatoon3TokenResponse
{
    [JsonProperty("correlationId")] public string CorrelationId { get; set; }

    [JsonProperty("result")] public Splatoon3TokenResponseResult Result { get; set; }
}

public class Splatoon3TokenResponseResult
{
    [JsonProperty("accessToken")] public string AccessToken { get; set; }

    [JsonProperty("expiresIn")] public string ExpiresIn { get; set; }
}