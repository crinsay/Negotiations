namespace Negotiations.Application.Negotiations.Dtos;

class NegotiationDeclinedDto
{
    public int Id { get; set; }
    public string Status { get; set; } = default!;
    public DateTime? DeclineDate { get; set; }
}
