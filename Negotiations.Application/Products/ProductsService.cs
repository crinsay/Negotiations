using Microsoft.Extensions.Logging;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;

namespace Negotiations.Application.Products;

internal class ProductsService(IProductsRepository productsRepository, ILogger<ProductsService> logger) : IProductsService
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        logger.LogInformation("Fetching all products from the repository.");
        var products = await productsRepository.GetAllProductsAsync();
        return products;
    }
}
