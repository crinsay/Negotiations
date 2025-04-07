namespace Negotiations.Application.Negotiations.Dtos;

public class NegotiationDto
{
    public int Id { get; set; }
    public decimal SuggestedPrice { get; set; }
    public bool? IsAccepted { get; set; }
    public DateTime? DeclineDate { get; set; }
}
