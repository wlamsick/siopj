using Common.Presentation.Endpoint.Filters;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.Http;

public static class ValidationFilterConfiguration
{
    public static RouteGroupBuilder AddFluentValidationFilter(this RouteGroupBuilder builder)
    {
        builder.AddEndpointFilter<FluentValidationEndpointFilter>();
        return builder;
    }
}
