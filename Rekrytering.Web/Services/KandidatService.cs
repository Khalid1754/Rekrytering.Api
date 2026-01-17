using System.Net.Http.Json;
using Rekrytering.Web.Models;

namespace Rekrytering.Web.Services;

public class KandidatService
{
    private readonly HttpClient _client;

    public KandidatService(HttpClient client)
    {
        _client = client;
        // OBS: Byt URL till din API-port
        _client.BaseAddress = new Uri("https://localhost:5001/");
    }

    public async Task<List<KandidatViewModel>> HamtaAllaAsync()
    {
        var kandidater = await _client.GetFromJsonAsync<List<KandidatViewModel>>("api/kandidater");
        return kandidater ?? new List<KandidatViewModel>();
    }

    public async Task SkapaAsync(KandidatViewModel kandidat)
    {
        await _client.PostAsJsonAsync("api/kandidater", kandidat);
    }
}   