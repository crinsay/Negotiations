using Negotiations.Domain.Entities;

namespace Negotiations.Domain.Repositories;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<int> CreateProductAsync(Product product);
    //Task UpdateProductAsync(Product product);
    //Task DeleteProductAsync(int id);
}
