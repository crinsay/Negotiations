using AutoMapper;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Products.Dtos;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Products;

internal class ProductsService(IProductsRepository productsRepository, 
    ILogger<ProductsService> logger,
    IMapper mapper) : IProductsService
{
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        logger.LogInformation("Fetching all products from the repository.");
        var products = await productsRepository.GetAllProductsAsync();
        var productsDtos = mapper.Map<IEnumerable<ProductDto>>(products);

        return productsDtos;
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        logger.LogInformation("Fetching product with ID {ProductId} from the repository.", id);
        var product = await productsRepository.GetProductByIdAsync(id);
        var productDto = mapper.Map<ProductDto?>(product);

        return productDto;
    }
}
