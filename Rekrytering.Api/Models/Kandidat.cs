namespace Rekrytering.Api.Models;

public class Kandidat
{
    public int Id { get; set; }
    public string Namn { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Kompetens { get; set; } = string.Empty;
    public KandidatStatus Status { get; set; }
}

public enum KandidatStatus
{
    Ansökt = 0,
    Intervju = 1,
    Anställd = 2,
    Avvisad = 3
}
