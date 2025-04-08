using MediatR;

namespace Negotiations.Application.Negotiations.Commands.SetNegotiationStatus;

public class SetNegotiationStatusCommand : IRequest
{
    public int ProductId { get; set; }
    public string Status { get; set; } = default!;
}
