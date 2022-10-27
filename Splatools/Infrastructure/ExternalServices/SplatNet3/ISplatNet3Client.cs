using System.Threading.Tasks;
using Splatools.Infrastructure.ExternalServices.SplatNet3.Models;

namespace Splatools.Infrastructure.ExternalServices.SplatNet3;

public interface ISplatNet3Client
{
    Task<ScheduleResponse> GetSchedule(string bulletToken);
}