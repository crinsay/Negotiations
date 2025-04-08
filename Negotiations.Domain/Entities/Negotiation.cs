namespace Negotiations.Domain.Entities;

public class Negotiation
{
    public int Id { get; set; }
    public int ProductId { get; set; } 
    public decimal SuggestedPrice { get; set; }
    public string Status { get; set; } = default!;
    public DateTime? DeclineDate { get; set; }
}
