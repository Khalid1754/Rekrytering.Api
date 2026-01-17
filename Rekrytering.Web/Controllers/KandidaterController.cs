using Microsoft.AspNetCore.Mvc;
using Rekrytering.Web.Models;
using Rekrytering.Web.Services;

namespace Rekrytering.Web.Controllers;

public class KandidaterController : Controller
{
    private readonly KandidatService _tjanst;

    public KandidaterController(KandidatService tjanst)
    {
        _tjanst = tjanst;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var kandidater = await _tjanst.HamtaAllaAsync();
            return View(kandidater);
        }
        catch (Exception ex)
        {
            // Visa felmeddelande
            ViewBag.Fel = ex.Message;
            return View(new List<KandidatViewModel>());
        }
    }

    [HttpGet]
    public IActionResult Skapa()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Skapa(KandidatViewModel kandidat)
    {
        if (!ModelState.IsValid)
            return View(kandidat);

        await _tjanst.SkapaAsync(kandidat);
        return RedirectToAction(nameof(Index));
    }
}