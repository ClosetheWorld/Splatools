using System.Collections.Generic;

namespace Splatools.Domain.Entities.Dto;

public class GetCurrentRegularMatchSettingResponse
{
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public List<string> StageName { get; set; }
}