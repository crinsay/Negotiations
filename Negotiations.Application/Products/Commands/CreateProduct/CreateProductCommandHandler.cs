using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Products.Dtos;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler(IProductsRepository productsRepository, 
    IMapper mapper, 
    ILogger<CreateProductCommandHandler> logger) : IRequestHandler<CreateProductCommand, int>
{
    public Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new product with name {ProductName}.", command.Name);
        var product = mapper.Map<Product>(command);


        var id = productsRepository.CreateProductAsync(product);
        return id;
    }
}
