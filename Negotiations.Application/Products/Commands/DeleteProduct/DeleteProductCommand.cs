using MediatR;

namespace Negotiations.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommand(int id) : IRequest
{
    public int Id { get; } = id;

}
