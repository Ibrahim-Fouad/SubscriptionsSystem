using Microsoft.Extensions.DependencyInjection;
using SubscriptionsSystem.Application.Abstractions;
using SubscriptionsSystem.Infrastructure.Repositories;

namespace SubscriptionsSystem.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}