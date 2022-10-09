using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class BulletTokenResponse
{
    [JsonProperty("bulletToken")] public string BulletToken { get; set; }
    [JsonProperty("is_noe_country")] public string IsNoeCountry { get; set; }
    [JsonProperty("lang")] public string Lang { get; set; }
}