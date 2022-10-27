using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Splatools.Domain.Services.Interfaces;

namespace Splatools.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class Splatoon3Controller
{
    private readonly ISplatoon3Service _splatoon3Service;

    public Splatoon3Controller(ISplatoon3Service splatoon3Service)
    {
        _splatoon3Service = splatoon3Service;
    }

    [HttpPost]
    public async Task<OkObjectResult> GetSchedule(string bulletToken)
    {
        var response = await _splatoon3Service.GetCurrentRegularMatchSetting(bulletToken);

        return new OkObjectResult(response);
    }
}