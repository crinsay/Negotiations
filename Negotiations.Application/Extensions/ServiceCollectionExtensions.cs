using Microsoft.Extensions.DependencyInjection;
using Negotiations.Application.Products;

namespace Negotiations.Application.Extensions;


public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductsService, ProductsService>();
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
    }
}
