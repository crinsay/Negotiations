using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Products.Dtos;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler(ILogger<GetProductByIdQueryHandler> logger,
    IMapper mapper,
    IProductsRepository productsRepository) : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching product with ID {ProductId} from the repository.", request.Id);
        var product = await productsRepository.GetProductByIdAsync(request.Id);
        var productDto = mapper.Map<ProductDto?>(product);

        return productDto;
    }
}
