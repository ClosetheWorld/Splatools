using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Splatools.Controllers;

[ApiController]
public class AuthController
{
    [HttpGet]
    public async Task<OkObjectResult> GenerateNintendoAuthURL()
    {
        return new OkObjectResult(new object());
    }
}