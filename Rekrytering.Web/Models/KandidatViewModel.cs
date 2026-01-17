namespace Rekrytering.Web.Models;

public class KandidatViewModel
{
    public int Id { get; set; }
    public string Namn { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Kompetens { get; set; } = string.Empty;
    public int Status { get; set; }
}