using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SubscriptionsSystem.Application.Profiles;

namespace SubscriptionsSystem.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(typeof(UserMappingProfile).Assembly);

        return services;
    }
}