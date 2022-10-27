using Newtonsoft.Json;

namespace Splatools.Infrastructure.ExternalServices.SplatNet3.Models;

public class GraphQLRequest
{
    [JsonProperty("variables")] public Variables Variables { get; set; }

    [JsonProperty("extensions")] public Extensions Extensions { get; set; }
}

public class Extensions
{
    [JsonProperty("persistedQuery")] public PersistedQuery PersistedQuery { get; set; }
}

public class PersistedQuery
{
    [JsonProperty("version")] public int Version { get; set; }

    [JsonProperty("sha256Hash")] public string Sha256Hash { get; set; }
}

public class Variables
{
}