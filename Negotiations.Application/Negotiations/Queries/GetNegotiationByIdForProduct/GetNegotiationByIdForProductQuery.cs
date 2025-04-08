using MediatR;
using Negotiations.Application.Negotiations.Dtos;

namespace Negotiations.Application.Negotiations.Queries.GetNegotiationByIdForProduct;

public class GetNegotiationByIdForProductQuery(int productId, int negotiationId) : IRequest<NegotiationDto>
{
    public int ProductId { get; set; } = productId;
    public int NegotiationId { get; set; } = negotiationId;
}