using System;
using System.Security.Cryptography;
using System.Text;

namespace Splatools.Domain.Helpers;

public static class ChallengeHelper
{
    public static string GenerateState()
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVQXYZ123456789_";
        var random = new Random();
        var state = new char[49];
        for (var i = 0; i < state.Length; i++)
            state[i] = chars[random.Next(chars.Length)];
        return new string(state);           
    }

    public static string GenerateCodeVerifier()
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVQXYZ123456789";
        var random = new Random();
        var verifier = new char[51];
        for (int i = 0; i < verifier.Length; i++)
            verifier[i] = chars[random.Next(chars.Length)];
        return new string(verifier);
    }

    public static string GenerateCodeChallenge(string verifier)
    {
        using var sha256 = SHA256.Create();
        var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(verifier));
        return Convert.ToBase64String(hash).Replace("+", "-").Replace("=", "").Replace("/", "_");
    }
}