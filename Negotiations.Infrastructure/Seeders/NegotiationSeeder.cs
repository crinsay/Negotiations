using Negotiations.Domain.Entities;
using Negotiations.Infrastructure.Persistence;

namespace Negotiations.Infrastructure.Seeders;

internal class NegotiationSeeder(NegotiationsDbContext dbContext) : INegotiationSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Negotiations.Any())
            {
                var products = GetProducts();
                dbContext.Products.AddRange(products);
                await dbContext.SaveChangesAsync();

                var negotiations = GetNegotiations();
                dbContext.Negotiations.AddRange(negotiations);
                await dbContext.SaveChangesAsync();
            }

        }
    }

    private IEnumerable<Product> GetProducts()
    {
        List<Product> products = [
            new()
            {
                Name = "Product 1",
                Price = 10.00m,
            },
            new()
            {
                Name = "Product 2",
                Price = 20.00m,
            },
            new()
            {
                Name = "Product 3",
                Price = 30.00m,
            },
            new()
            {
                Name = "Product 4",
                Price = 40.00m,
            },
            new()
            {
                Name = "Product 5",
                Price = 50.00m,
            }
            ];

        return products;
    }

    private IEnumerable<Negotiation> GetNegotiations()
    {
        List<Negotiation> negotiations = [
            new()
            {
                ProductId = 1,
                SuggestedPrice = 50.00m,
                Status = "Pending",
            },
            new()
            {
                ProductId = 2,
                SuggestedPrice = 40.00m,
                Status = "Accepted",
            },
            new()
            {
                ProductId = 3,
                SuggestedPrice = 30.00m,
                Status = "Declined",
                DeclineDate = DateTime.UtcNow.AddDays(-10),
            },
            new()
            {
                ProductId = 3,
                SuggestedPrice = 60.00m,
                Status = "Pending",
            },
            new()
            {
                ProductId = 4,
                SuggestedPrice = 70.00m,
                Status = "Declined",
                DeclineDate = DateTime.UtcNow.AddDays(-5),
            },
            new()
            {
                ProductId = 5,
                SuggestedPrice = 80.00m,
                Status = "Declined",
                DeclineDate = DateTime.UtcNow.AddDays(-2),
            },
            new()
            {
                ProductId = 5,
                SuggestedPrice = 90.00m,
                Status = "Declined",
                DeclineDate = DateTime.UtcNow.AddDays(-2),
            },
            new()
            {
                ProductId = 5,
                SuggestedPrice = 40.00m,
                Status = "Declined",
                DeclineDate = DateTime.UtcNow.AddDays(-1),
            }
        ];
        return negotiations;
    }
}
