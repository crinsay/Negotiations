using MediatR;

namespace Negotiations.Application.Negotiations.Commands;

public class CreateNegotiationCommand : IRequest<int> 
{
    public decimal SuggestedPrice { get; set; }
    public int ProductId { get; set; }
}
