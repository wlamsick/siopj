using Microsoft.AspNetCore.Routing;

namespace Common.Presentation.Endpoints.Abstraction;

public interface IEndpointModule
{
    void ConfigureEndpoints(IEndpointRouteBuilder app);
}
