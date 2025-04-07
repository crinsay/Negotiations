using MediatR;
using Negotiations.Application.Products.Dtos;

namespace Negotiations.Application.Products.Queries.GetAllProductsQuery;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
{

}
