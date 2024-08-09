using Common.Application.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace SiopjModule.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddDefaultServices();
        return services;
    }
}
