using Newtonsoft.Json;

namespace Splatools.Domain.Entities.Dto;

public class FirebaseCredential
{
    [JsonProperty("accessToken")] public string AccessToken { get; set; }

    [JsonProperty("expiresIn")] public int ExpiresIn { get; set; }
}

public class FriendCode
{
    [JsonProperty("regenerable")] public bool Regenerable { get; set; }

    [JsonProperty("regenerableAt")] public int RegenerableAt { get; set; }

    [JsonProperty("id")] public string Id { get; set; }
}

public class Game
{
}

public class Links
{
    [JsonProperty("nintendoAccount")] public NintendoAccount NintendoAccount { get; set; }

    [JsonProperty("friendCode")] public FriendCode FriendCode { get; set; }
}

public class Membership
{
    [JsonProperty("active")] public bool Active { get; set; }
}

public class NintendoAccount
{
    [JsonProperty("membership")] public Membership Membership { get; set; }
}

public class Permissions
{
    [JsonProperty("presence")] public string Presence { get; set; }
}

public class Presence
{
    [JsonProperty("state")] public string State { get; set; }

    [JsonProperty("updatedAt")] public int UpdatedAt { get; set; }

    [JsonProperty("logoutAt")] public int LogoutAt { get; set; }

    [JsonProperty("game")] public Game Game { get; set; }
}

public class Result
{
    [JsonProperty("user")] public User User { get; set; }

    [JsonProperty("webApiServerCredential")]
    public WebApiServerCredential WebApiServerCredential { get; set; }

    [JsonProperty("firebaseCredential")] public FirebaseCredential FirebaseCredential { get; set; }
}

public class NintendoSwitchOnlineTokenResponse
{
    [JsonProperty("status")] public int Status { get; set; }

    [JsonProperty("result")] public Result Result { get; set; }

    [JsonProperty("correlationId")] public string CorrelationId { get; set; }
}

public class User
{
    [JsonProperty("id")] public long Id { get; set; }

    [JsonProperty("nsaId")] public string NsaId { get; set; }

    [JsonProperty("imageUri")] public string ImageUri { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("supportId")] public string SupportId { get; set; }

    [JsonProperty("isChildRestricted")] public bool IsChildRestricted { get; set; }

    [JsonProperty("etag")] public string Etag { get; set; }

    [JsonProperty("links")] public Links Links { get; set; }

    [JsonProperty("permissions")] public Permissions Permissions { get; set; }

    [JsonProperty("presence")] public Presence Presence { get; set; }
}

public class WebApiServerCredential
{
    [JsonProperty("accessToken")] public string AccessToken { get; set; }

    [JsonProperty("expiresIn")] public int ExpiresIn { get; set; }
}