using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class NintendoAppTokenRequest
{
    [JsonProperty("parameter")] public Parameter Parameter { get; set; }
    [JsonProperty("requetId")] public string RequestId { get; set; }
}

public class Parameter
{
    [JsonProperty("language")] public string Language = "ja-JP";
    [JsonProperty("naCountry")] public string NaCountry = "JP";

    [JsonProperty("f")] public string F { get; set; }

    [JsonProperty("naBirthday")] public string NaBirthDay { get; set; }
    [JsonProperty("naIdToken")] public string NaIdToken { get; set; }
    [JsonProperty("requestId")] public string RequestId { get; set; }
    [JsonProperty("timestamp")] public string TimeStamp { get; set; }
}