using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class NintendoSwitchOnlineTokenRequest
{
    [JsonProperty("parameter")] public NsoTokenParams Parameter { get; set; }
    [JsonProperty("requetId")] public string RequestId { get; set; }
}

public class NsoTokenParams
{
    [JsonProperty("language")] public string Language = "ja-JP";
    [JsonProperty("naCountry")] public string NaCountry = "JP";

    [JsonProperty("f")] public string F { get; set; }

    [JsonProperty("naBirthday")] public string NaBirthDay { get; set; }
    [JsonProperty("naIdToken")] public string NaIdToken { get; set; }
    [JsonProperty("requestId")] public string RequestId { get; set; }
    [JsonProperty("timestamp")] public string TimeStamp { get; set; }
}