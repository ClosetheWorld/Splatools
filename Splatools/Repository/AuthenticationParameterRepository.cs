using System.Threading.Tasks;
using Splatools.Domain.Entities;
using Splatools.Infrastructure.Database;
using Splatools.Repository.Interfaces;

namespace Splatools.Repository;

public class AuthenticationParameterRepository : IAuthenticationParameterRepository
{
    private readonly SplatDbContext _db;

    public AuthenticationParameterRepository(SplatDbContext db)
    {
        _db = db;
    }

    public async Task InsertAuthenticationParameter(AuthenticationParameter req)
    {
        await _db.AuthenticationParameters.AddAsync(req);
        await _db.SaveChangesAsync();
    }
}