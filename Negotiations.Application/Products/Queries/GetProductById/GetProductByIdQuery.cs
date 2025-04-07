using MediatR;
using Negotiations.Application.Products.Dtos;

namespace Negotiations.Application.Products.Queries.GetProductById;

public class GetProductByIdQuery(int id) : IRequest<ProductDto>
{
    public int Id { get; set; } = id;
}
