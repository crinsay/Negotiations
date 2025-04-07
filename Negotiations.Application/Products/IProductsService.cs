using Negotiations.Domain.Entities;

namespace Negotiations.Application.Products;
public interface IProductsService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
}