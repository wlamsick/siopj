using SiopjModule.Presentation.Endpoints.ProgramaOperacional;

namespace SiopjModule.Presentation.Modules;

public sealed class SiopjEndpointModule : IEndpointModule
{
    public void ConfigureEndpoints(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();

        var root = app.MapGroup("api/siopj")
            .WithApiVersionSet(apiVersionSet)
            .WithTags("User Endpoints")
            .AddFluentValidationFilter();

        MapProgramaOperaciones(root);   
    }

    private void MapProgramaOperaciones(IEndpointRouteBuilder app)
    {
        var root = app.MapGroup("programa-operacional")
            .WithTags("Programa Operacional Endpoints")
            .AddFluentValidationFilter();

        root.RegisterEndpoint<GetAllProgramaOperacionalEndpoint>();
    }
}
