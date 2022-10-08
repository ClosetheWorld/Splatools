using System;
using System.Text;
using System.Threading.Tasks;
using Splatools.Domain.Entities;
using Splatools.Domain.Entities.Dto;
using Splatools.Domain.Entities.ValueObjects;
using Splatools.Domain.Helpers;
using Splatools.Domain.Services.Interfaces;
using Splatools.Repository.Interfaces;

namespace Splatools.Domain.Services;

public class GetNintendoAuthUrl : IGetNintendoAuthUrl
{
    private readonly IAuthenticationParameterRepository _repository;

    public GetNintendoAuthUrl(IAuthenticationParameterRepository repository)
    {
        _repository = repository;
    }

    public async Task<NintendoAuthResponse> GetAuthUrl()
    {
        var key = Guid.NewGuid();
        var state = ChallengeHelper.GenerateState();
        var verifier = ChallengeHelper.GenerateCodeVerifier();
        var challenge = ChallengeHelper.GenerateCodeChallenge(verifier);

        await CallInsertAuthenticationParameterAsync(new AuthenticationParameter()
        {
            Key = key,
            Verifier = verifier,
            InsertionTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
        });

        return new NintendoAuthResponse
        {
            AuthUrl = CreateAuthUrl(state, challenge),
            Key = key.ToString()
        };
    }

    private string CreateAuthUrl(string state, string challenge)
    {
        var sb = new StringBuilder();
        sb.Append(NintendoConstants.NintendoAuthBaseUrl);
        sb.Append($"?state={state}");
        sb.Append($"&redirect_uri={NintendoConstants.NintendoRedirectUri}");
        sb.Append($"&client_id={NintendoConstants.NintendoClientId}");
        sb.Append($"&scope={NintendoConstants.NintendoAuthScope}");
        sb.Append($"&response_type={NintendoConstants.NintendoResponseType}");
        sb.Append($"&session_token_code_challenge={challenge}");
        sb.Append($"&session_token_code_challenge_method={NintendoConstants.NintendoChallengeMethod}");
        sb.Append($"&theme={NintendoConstants.NintendoRequestTheme}");

        return sb.ToString();
    }

    private async Task CallInsertAuthenticationParameterAsync(AuthenticationParameter req)
    {
        await _repository.InsertAuthenticationParameter(req);
    }
}