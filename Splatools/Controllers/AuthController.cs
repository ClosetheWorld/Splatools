using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Splatools.Domain.Entities.Dto;
using Splatools.Domain.Services.Interfaces;

namespace Splatools.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController
{
    private readonly INintendoUrlService _nintendoUrlService;
    private readonly ITokenService _tokenService;

    public AuthController(INintendoUrlService nintendoUrlService, ITokenService tokenService)
    {
        _nintendoUrlService = nintendoUrlService;
        _tokenService = tokenService;
    }

    [HttpGet("url")]
    public async Task<OkObjectResult> GetUrl()
    {
        var response = await _nintendoUrlService.GetAuthUrl();

        return new OkObjectResult(response);
    }

    [HttpPost("splatoken")]
    public async Task<IActionResult> GetSplatoken(GetSplatokenRequest req)
    {
        var response = await _tokenService.GetSplatoken(req);

        return new OkObjectResult(response);
    }
}