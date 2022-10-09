using Newtonsoft.Json;

namespace Splatools.Infrastructure.ExternalServices.F;

public class FResponse
{
    [JsonProperty("request_id")] public string RequestId { get; set; }

    [JsonProperty("timestamp")] public string TimeStamp { get; set; }

    [JsonProperty("f")] public string F { get; set; }
}