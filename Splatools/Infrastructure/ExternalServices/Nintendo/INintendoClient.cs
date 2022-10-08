using System.Threading.Tasks;

namespace Splatools.Infrastructure.ExternalServices.Nintendo;

public interface INintendoClient
{
    Task<MeResponse> GetMe(string accessToken);
}