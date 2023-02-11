using SubscriptionsSystem.API.Middlewares;
using SubscriptionsSystem.Application.Options;

namespace SubscriptionsSystem.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.JwtConfigKey));
        services.AddTransient<GlobalExceptionHandlerMiddleware>();
        return services;
    }
}