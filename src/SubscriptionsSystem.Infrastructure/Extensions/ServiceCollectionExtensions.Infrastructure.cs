using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Infrastructure.Repositories;

namespace SubscriptionsSystem.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<IProductsRepository, ProductsRepository>();
        return services;
    }
}