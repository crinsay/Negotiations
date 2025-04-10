﻿using Microsoft.EntityFrameworkCore;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;
using Negotiations.Infrastructure.Persistence;

namespace Negotiations.Infrastructure.Repositories;

internal class ProductsRepository(NegotiationsDbContext dbContext) : IProductsRepository
{
    public async Task<int> CreateProductAsync(Product product)
    {
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();
        return product.Id;
    }

    public async Task DeleteProductAsync(Product product)
    {
        dbContext.Remove(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var product = await dbContext.Products
            .Include(p => p.Negotiations)
            .FirstOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public Task SaveChanges() => dbContext.SaveChangesAsync();
}
