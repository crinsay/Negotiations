namespace Negotiations.Domain.Entities;

public class Negotiation
{
    public int Id { get; set; }
    public int ProductId { get; set; } 
    public decimal SuggestedPrice { get; set; }
    public bool? IsAccepted { get; set; }
    public DateTime? DeclineDate { get; set; }
}
