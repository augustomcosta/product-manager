using CrudProductManager.API.Data.Database.Context;
using CrudProductManager.API.Data.RepositoriesImpl;
using CrudProductManager.API.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrudProductManager.API.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")
            )
        );

        services.AddScoped<IProductRepository, ProductRepositoryImpl>();

        return services;
    }
}