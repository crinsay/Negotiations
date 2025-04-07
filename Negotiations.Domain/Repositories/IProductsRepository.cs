using Negotiations.Domain.Entities;

namespace Negotiations.Domain.Repositories;

public interface IProductsRepository
{
    //Task<Product> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    //Task AddProductAsync(Product product);
    //Task UpdateProductAsync(Product product);
    //Task DeleteProductAsync(int id);
}
