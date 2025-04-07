using AutoMapper;
using Microsoft.Extensions.Logging;
using Negotiations.Application.Products.Dtos;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Products;

internal class ProductsService(IProductsRepository productsRepository, 
    ILogger<ProductsService> logger,
    IMapper mapper) : IProductsService
{
    public Task<int> CreateProductAsync(ProductDto productDto)
    {
        logger.LogInformation("Creating a new product with name {ProductName}.", productDto.Name);
        var product = mapper.Map<Product>(productDto);

        var id = productsRepository.CreateProductAsync(product);
        return id;
    }

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
