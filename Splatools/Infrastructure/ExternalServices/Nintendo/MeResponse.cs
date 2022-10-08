using System.Collections.Generic;
using Newtonsoft.Json;

namespace Splatools.Infrastructure.ExternalServices.Nintendo;

public class AnalyticsPermissions
{
    [JsonProperty("targetMarketing")] public TargetMarketing TargetMarketing { get; set; }

    [JsonProperty("internalAnalysis")] public InternalAnalysis InternalAnalysis { get; set; }
}

public class Deals
{
    [JsonProperty("optedIn")] public bool OptedIn { get; set; }

    [JsonProperty("updatedAt")] public int UpdatedAt { get; set; }
}

public class EachEmailOptedIn
{
    [JsonProperty("deals")] public Deals Deals { get; set; }

    [JsonProperty("survey")] public Survey Survey { get; set; }
}

public class InternalAnalysis
{
    [JsonProperty("permitted")] public bool Permitted { get; set; }

    [JsonProperty("updatedAt")] public int UpdatedAt { get; set; }
}

public class MeResponse
{
    [JsonProperty("emailOptedIn")] public bool EmailOptedIn { get; set; }

    [JsonProperty("analyticsPermissions")] public AnalyticsPermissions AnalyticsPermissions { get; set; }

    [JsonProperty("analyticsOptedIn")] public bool AnalyticsOptedIn { get; set; }

    [JsonProperty("emailOptedInUpdatedAt")]
    public int EmailOptedInUpdatedAt { get; set; }

    [JsonProperty("gender")] public string Gender { get; set; }

    [JsonProperty("nickname")] public string Nickname { get; set; }

    [JsonProperty("screenName")] public string ScreenName { get; set; }

    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("analyticsOptedInUpdatedAt")]
    public int AnalyticsOptedInUpdatedAt { get; set; }

    [JsonProperty("clientFriendsOptedInUpdatedAt")]
    public int ClientFriendsOptedInUpdatedAt { get; set; }

    [JsonProperty("region")] public object Region { get; set; }

    [JsonProperty("language")] public string Language { get; set; }

    [JsonProperty("clientFriendsOptedIn")] public bool ClientFriendsOptedIn { get; set; }

    [JsonProperty("country")] public string Country { get; set; }

    [JsonProperty("birthday")] public string Birthday { get; set; }

    [JsonProperty("eachEmailOptedIn")] public EachEmailOptedIn EachEmailOptedIn { get; set; }

    [JsonProperty("candidateMiis")] public List<object> CandidateMiis { get; set; }

    [JsonProperty("createdAt")] public int CreatedAt { get; set; }

    [JsonProperty("updatedAt")] public int UpdatedAt { get; set; }

    [JsonProperty("timezone")] public Timezone Timezone { get; set; }

    [JsonProperty("emailVerified")] public bool EmailVerified { get; set; }

    [JsonProperty("isChild")] public bool IsChild { get; set; }

    [JsonProperty("mii")] public object Mii { get; set; }
}

public class Survey
{
    [JsonProperty("updatedAt")] public int UpdatedAt { get; set; }

    [JsonProperty("optedIn")] public bool OptedIn { get; set; }
}

public class TargetMarketing
{
    [JsonProperty("updatedAt")] public int UpdatedAt { get; set; }

    [JsonProperty("permitted")] public bool Permitted { get; set; }
}

public class Timezone
{
    [JsonProperty("utcOffset")] public string UtcOffset { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("utcOffsetSeconds")] public int UtcOffsetSeconds { get; set; }
}