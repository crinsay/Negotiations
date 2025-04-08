using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Negotiations.Domain.Entities;
using Negotiations.Domain.Repositories;
using Negotiations.Infrastructure.Persistence;
using Negotiations.Infrastructure.Repositories;

namespace Negotiations.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("NegotiationsDb");
        services.AddDbContext<NegotiationsDbContext>(options =>
                options
                    .UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging());

        services.AddIdentityApiEndpoints<Employee>()
            .AddEntityFrameworkStores<NegotiationsDbContext>();

        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<INegotiationsRepository, NegotiationsRepository>();
    }

}