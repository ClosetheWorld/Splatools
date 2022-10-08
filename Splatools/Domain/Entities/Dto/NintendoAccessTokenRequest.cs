using Newtonsoft.Json;
using Splatools.Domain.Entities.ValueObjects;

namespace Splatools.Domain.Entities.Dto;

public class NintendoAccessTokenRequest
{
    [JsonProperty("client_id")] public string ClientId = NintendoConstants.NintendoClientId;
    [JsonProperty("grant_type")] public string GrantType = NintendoConstants.NintendoAccessTokenGrantType;

    [JsonProperty("session_token")] public string SessionToken { get; set; }
}