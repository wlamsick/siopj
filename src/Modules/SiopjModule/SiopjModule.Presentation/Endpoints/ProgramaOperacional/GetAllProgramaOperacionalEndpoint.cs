using Common.Presentation.Endpoints;
using Common.Presentation.Endpoints.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using SiopjModule.Application.Features.ProgramaOperaciones.Queries.GetAllProgramaOperacional;

namespace SiopjModule.Presentation.Endpoints.ProgramaOperacional;

public sealed class GetAllProgramaOperacionalEndpoint : IEndpoint
{
    public IEndpointConventionBuilder MapEndpoint(IEndpointRouteBuilder app)
    {
        return app.MapGet("/", async (ISender sender, CancellationToken ct) =>
        {
            var result = await sender.Send(new GetAllProgramaOperacionalQuery(), ct);
            return result.ToHttpResponse();
        });
    }
}
