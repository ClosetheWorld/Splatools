using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class NintendoSessionTokenResponse
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("session_token")]
    public string SessionToken { get; set; }
}