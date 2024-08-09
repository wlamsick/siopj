using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Orchestrator.Extensions;

public static class MassTransitExtensions
{
    public static void AddRequestClients(this IServiceCollection services, params Assembly[] assemblies)
    {
        
        var requestClientTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IRequestClient<>) || i.GetGenericTypeDefinition() == typeof(IMessageRequest))))
            .Select(t => new
            {
                ServiceType = typeof(IRequestClient<>).MakeGenericType(t.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestClient<>)).GenericTypeArguments[0]),
                ImplementationType = t
            });

        foreach (var requestClientType in requestClientTypes)
        {
            services.AddScoped(requestClientType.ServiceType, requestClientType.ImplementationType);
        }     
    }
}
