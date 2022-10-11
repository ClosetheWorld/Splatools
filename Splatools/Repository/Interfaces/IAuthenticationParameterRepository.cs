using System;
using System.Threading.Tasks;
using Splatools.Domain.Entities;

namespace Splatools.Repository.Interfaces;

public interface IAuthenticationParameterRepository
{
    Task InsertAuthenticationParameter(AuthenticationParameter req);
    Task<string> GetSessionTokenCodeVerifier(Guid key);
    Task DeleteAuthenticationParameter(string key);
}