using MediatR;
namespace Negotiations.Application.Negotiations.Commands.CreateNegotiation;

public class CreateNegotiationCommand : IRequest<int> 
{
    public decimal SuggestedPrice { get; set; }
    public int ProductId { get; set; }
}
