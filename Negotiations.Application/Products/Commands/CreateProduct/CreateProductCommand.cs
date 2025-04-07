using MediatR;
using Negotiations.Domain.Entities;

namespace Negotiations.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
}
