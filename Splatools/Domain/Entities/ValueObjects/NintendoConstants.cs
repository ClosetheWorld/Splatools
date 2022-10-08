namespace Splatools.Domain.Entities.ValueObjects;

public static class NintendoConstants
{
    public const string NintendoAuthBaseUrl = "https://accounts.nintendo.com/connect/1.0.0/authorize";
    public const string NintendoRedirectUri = "npf71b963c1b7b6d119%3A%2F%2Fauth";
    public const string NintendoClientId = "71b963c1b7b6d119";
    public const string NintendoAuthScope = "openid+user+user.birthday+user.mii+user.screenName";
    public const string NintendoResponseType = "session_token_code";
    public const string NintendoChallengeMethod = "S256";
    public const string NintendoRequestTheme = "login_form";
    public const string NintendoSessionTokenEndpoint = "https://accounts.nintendo.com/connect/1.0.0/api/session_token";
    public const string NintendoAccessTokenEndpoint = "https://accounts.nintendo.com/connect/1.0.0/api/token";
    public const string NintendoAppTokenEndpoint = "https://api-lp1.znc.srv.nintendo.net/v3/Account/Login";
}