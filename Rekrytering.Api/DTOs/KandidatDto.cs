using Rekrytering.Api.Models;

namespace Rekrytering.Api.DTOs;

public class KandidatDto
{
    public int Id { get; set; }
    public string Namn { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Kompetens { get; set; } = string.Empty;
    public KandidatStatus Status { get; set; }
}