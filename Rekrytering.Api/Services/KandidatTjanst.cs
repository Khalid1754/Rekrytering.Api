using Microsoft.EntityFrameworkCore;
using Rekrytering.Api.Data;
using Rekrytering.Api.Models;

namespace Rekrytering.Api.Tjanster;

public class KandidatTjanst
{
    private readonly ApplikationDbContext _context;

    public KandidatTjanst(ApplikationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Kandidat>> HamtaAllaAsync()
    {
        return await _context.Kandidater.ToListAsync();
    }

    public async Task<Kandidat?> HamtaMedIdAsync(int id)
    {
        return await _context.Kandidater.FindAsync(id);
    }

    public async Task<Kandidat> SkapaAsync(Kandidat kandidat)
    {
        _context.Kandidater.Add(kandidat);
        await _context.SaveChangesAsync();
        return kandidat;
    }
}