namespace Negotiations.Application.Negotiations.Dtos;

public class NegotiationDto
{
    public int Id { get; set; }
    public decimal SuggestedPrice { get; set; }
    public string Status { get; set; } = default!;
    public DateTime? DeclineDate { get; set; }
}
