using MediatR;
using Negotiations.Application.Negotiations.Dtos;

namespace Negotiations.Application.Negotiations.Queries.GetAllNegotiationsForProduct;

public class GetAllNegotiationsForProductQuery(int productId) : IRequest<IEnumerable<NegotiationDto>>
{
    public int ProductId { get; set; } = productId;
}
