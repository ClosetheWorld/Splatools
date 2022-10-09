using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class Splatoon3TokenRequest
{
    [JsonProperty("parameter")] public Splat3TokenParams Parameter { get; set; }
    [JsonProperty("requestId")] public string RequestId { get; set; }
}

public class Splat3TokenParams
{
    [JsonProperty("f")] public string F { get; set; }
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("registrationToken")] public string RegistrationToken { get; set; }

    [JsonProperty("requestId")] public string RequestId { get; set; }
    [JsonProperty("timestamp")] public string TimeStamp { get; set; }
}