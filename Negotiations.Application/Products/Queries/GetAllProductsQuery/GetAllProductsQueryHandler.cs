using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Products.Dtos;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Products.Queries.GetAllProductsQuery;

public class GetAllProductsQueryHandler(ILogger<GetAllProductsQueryHandler> logger,
    IProductsRepository productsRepository,
    IMapper mapper) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {    
        logger.LogInformation("Fetching all products from the repository.");
        var products = await productsRepository.GetAllProductsAsync();
        var productsDtos = mapper.Map<IEnumerable<ProductDto>>(products);

        return productsDtos;
    }

}
