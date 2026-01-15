using Microsoft.EntityFrameworkCore;
using Rekrytering.Api.Models;

namespace Rekrytering.Api.Data;

public class ApplikationDbContext : DbContext
{
    public ApplikationDbContext(DbContextOptions<ApplikationDbContext> options)
    : base(options)
    {
    }

    public DbSet<Kandidat> Kandidater => Set<Kandidat>();
}
