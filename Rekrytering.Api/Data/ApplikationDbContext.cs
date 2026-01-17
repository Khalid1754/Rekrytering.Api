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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Kandidat>().HasData(
            new Kandidat
            {
                Id = 1,
                Namn = "Khalid Hassan",
                Email = "Khalid.Hassan@example.com",
                Kompetens = "Backend",
                Status = KandidatStatus.Ansökt
            },
            new Kandidat
            {
                Id = 2,
                Namn = "´Gandalf Grey",
                Email = "Gandalf.Grey@example.com",
                Kompetens = "Frontend",
                Status = KandidatStatus.Intervju
            },
            new Kandidat
            {
                Id = 3,
                Namn = "Drake OVO",
                Email = "Drake.OVO@example.com",
                Kompetens = "Fullstack",
                Status = KandidatStatus.Anställd
            }
        );
    }
}