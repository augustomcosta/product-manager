using Microsoft.EntityFrameworkCore;
using Product_Manager.Data.Database.Context;
using Product_Manager.Data.RepositoriesImpl;
using Product_Manager.Domain.Repositories;
namespace Product_Manager.Infra;

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