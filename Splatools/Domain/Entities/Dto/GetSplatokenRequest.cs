using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class GetSplatokenRequest
{
    [JsonProperty("uri")]
    public string Uri { get; set; }
    
    [JsonProperty("key")]
    public string Key { get; set; }
}