using Microsoft.AspNetCore.Mvc;
using Rekrytering.Api.DTOs;
using Rekrytering.Api.Models;
using Rekrytering.Api.Tjanster;

namespace Rekrytering.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KandidaterController : ControllerBase
{
    private readonly KandidatTjanst _tjanst;

    public KandidaterController(KandidatTjanst tjanst)
    {
        _tjanst = tjanst;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<KandidatDto>>> HamtaAlla()
    {
        var kandidater = await _tjanst.HamtaAllaAsync();

        var resultat = kandidater.Select(k => new KandidatDto
        {
            Id = k.Id,
            Namn = k.Namn,
            Email = k.Email,
            Kompetens = k.Kompetens,
            Status = k.Status
        });

        return Ok(resultat);
    }

    [HttpPost]
    public async Task<ActionResult<KandidatDto>> Skapa(SkapaKandidatDto dto)
    {
        var kandidat = new Kandidat
        {
            Namn = dto.Namn,
            Email = dto.Email,
            Kompetens = dto.Kompetens,
            Status = KandidatStatus.Ansökt
        };

        await _tjanst.SkapaAsync(kandidat);

        return CreatedAtAction(nameof(HamtaAlla), new { id = kandidat.Id }, kandidat);
    }
}