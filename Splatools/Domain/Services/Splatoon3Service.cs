using System.Collections.Generic;
using System.Threading.Tasks;
using Splatools.Domain.Entities.Dto;
using Splatools.Domain.Services.Interfaces;
using Splatools.Infrastructure.ExternalServices.SplatNet3;
using Splatools.Infrastructure.ExternalServices.SplatNet3.Models;

namespace Splatools.Domain.Services;

public class Splatoon3Service : ISplatoon3Service
{
    private readonly ISplatNet3Client _client;

    public Splatoon3Service(ISplatNet3Client client)
    {
        _client = client;
    }

    public async Task<GetCurrentRegularMatchSettingResponse> GetCurrentRegularMatchSetting(string bulletToken)
    {
        var allSchedule = await _client.GetSchedule(bulletToken);
        var response = new GetCurrentRegularMatchSettingResponse
        {
            StartDate = allSchedule.Data.RegularSchedules.Nodes[0].StartTime.UtcDateTime.AddHours(9)
                .ToString("yyyy/MM/dd hh:mm:ss"),
            EndDate = allSchedule.Data.RegularSchedules.Nodes[0].EndTime.UtcDateTime.AddHours(9)
                .ToString("yyyy/MM/dd hh:mm:ss"),
            StageName = new List<string>
            {
                allSchedule.Data.RegularSchedules.Nodes[0].RegularMatchSetting.VsStages[0].Name,
                allSchedule.Data.RegularSchedules.Nodes[0].RegularMatchSetting.VsStages[1].Name,
            }
        };


        return response;
    }
}