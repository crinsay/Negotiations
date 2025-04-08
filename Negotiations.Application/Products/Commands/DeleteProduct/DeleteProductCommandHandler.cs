using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler(ILogger<DeleteProductCommandHandler> logger,
    IProductsRepository productsRepository) : IRequestHandler<DeleteProductCommand>
{
    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting product with id : {ProductId}", request.Id);
        var product = await productsRepository.GetProductByIdAsync(request.Id);
        if (product is null)
        {
            //todo: throw custom exception
        }

        await productsRepository.DeleteProductAsync(product);
    }
}

