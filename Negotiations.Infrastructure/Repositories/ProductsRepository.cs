using Microsoft.EntityFrameworkCore;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;
using Negotiations.Infrastructure.Persistence;

namespace Negotiations.Infrastructure.Repositories;

internal class ProductsRepository(NegotiationsDbContext dbContext) : IProductsRepository
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        return products;
    }
}
