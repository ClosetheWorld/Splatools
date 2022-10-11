using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

    public async Task<string> GetSessionTokenCodeVerifier(Guid key)
    {
        return await _db.AuthenticationParameters.Where(x => x.Key == key).Select(x => x.Verifier)
            .FirstOrDefaultAsync();
    }

    public async Task DeleteAuthenticationParameter(string key)
    {
        var target = await _db.AuthenticationParameters.Where(x => x.Key == new Guid(key)).FirstOrDefaultAsync();
        if (target != null)
        {
            _db.AuthenticationParameters.Remove(target);
            await _db.SaveChangesAsync();
        }
    }
}