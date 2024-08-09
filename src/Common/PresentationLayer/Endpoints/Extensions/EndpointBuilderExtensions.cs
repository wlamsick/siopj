using Common.Presentation.Endpoints.Abstraction;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.Routing;

public static class EndpointBuilderExtensions
{
    public static IEndpointConventionBuilder RegisterEndpoint<TEndpoint>(this IEndpointRouteBuilder root)
        where TEndpoint : IEndpoint, new()
    {
        var endpoint = new TEndpoint();
        return endpoint.MapEndpoint(root);
    }

    public static IEndpointRouteBuilder MapEndpointModule<TModule>(this IEndpointRouteBuilder app)
        where TModule : class, IEndpointModule, new()
    {
        var module = new TModule();
        module.ConfigureEndpoints(app);
        return app;
    }
}
