using System.Threading.Tasks;

namespace Splatools.Infrastructure.ExternalServices.F;

public interface IFClient
{
    Task<FResponse> GetFForNsO(string token);
    Task<FResponse> GetFForWebApp(string token);
}