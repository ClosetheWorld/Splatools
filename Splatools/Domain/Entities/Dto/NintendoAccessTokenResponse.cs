using System.Collections.Generic;
using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class NintendoAccessTokenResponse
{
    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }
    
    [JsonProperty("token_type")]
    public string TokenType { get; set; }
    
    [JsonProperty("scope")]
    public List<string> Scope { get; set; }
    
    [JsonProperty("id_token")]
    public string IdToken { get; set; }
    
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
}