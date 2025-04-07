using Negotiations.Application.Products.Dtos;

namespace Negotiations.Application.Products;
public interface IProductsService
{
    Task<IEnumerable<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int id);
    Task<int> CreateProductAsync(ProductDto productDto);
}