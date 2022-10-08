using Microsoft.EntityFrameworkCore;
using Splatools.Domain.Entities;

namespace Splatools.Infrastructure.Database;

public class SplatDbContext : DbContext
{
    public SplatDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AuthenticationParameter> AuthenticationParameters { get; set; }
}