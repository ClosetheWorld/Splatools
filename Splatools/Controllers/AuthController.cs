using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Splatools.Domain.Services.Interfaces;

namespace Splatools.Controllers;

[ApiController]
[Route("/api/url")]
public class AuthController
{
    private readonly IGetNintendoAuthUrl _getNintendoAuthUrl;

    public AuthController(IGetNintendoAuthUrl getNintendoAuthUrl)
    {
        _getNintendoAuthUrl = getNintendoAuthUrl;
    }

    [HttpGet]
    public async Task<OkObjectResult> GetUrl()
    {
        var response = await _getNintendoAuthUrl.GetAuthUrl();
        
        return new OkObjectResult(response);
    }
}