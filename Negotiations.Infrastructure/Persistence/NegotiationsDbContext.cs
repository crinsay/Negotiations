using Microsoft.EntityFrameworkCore;
using Negotiations.Domain.Entities;

namespace Negotiations.Infrastructure.Persistence;

internal class NegotiationsDbContext(DbContextOptions<NegotiationsDbContext> options) : DbContext(options)
{
    internal DbSet<Product> Products { get; set; }
    internal DbSet<Negotiation> Negotiations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Negotiations)
            .WithOne()
            .HasForeignKey(p => p.ProductId);
    }
}
