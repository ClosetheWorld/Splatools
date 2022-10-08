using System.Threading.Tasks;

namespace Splatools.Infrastructure.ExternalServices.F;

public interface IFClient
{
    Task<FResponse> GetF(string token);
}