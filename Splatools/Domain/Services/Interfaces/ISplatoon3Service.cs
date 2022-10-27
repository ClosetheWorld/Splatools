using System.Threading.Tasks;
using Splatools.Domain.Entities.Dto;

namespace Splatools.Domain.Services.Interfaces;

public interface ISplatoon3Service
{
    Task<GetCurrentRegularMatchSettingResponse> GetCurrentRegularMatchSetting(string bulletToken);
}