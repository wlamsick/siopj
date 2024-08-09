using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Common.Infraestructure.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static TOptions RegisterConfiguration<TOptions>(this WebApplicationBuilder builder, string sectionName) where TOptions : class
    {
        var config = builder.Configuration.GetSection(sectionName) ?? throw new InvalidOperationException($"Section {sectionName} not found in configuration");

        builder.Services.Configure<TOptions>(
            builder.Configuration.GetSection(sectionName)
        );

        builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<TOptions>>().Value);

        return builder.Services.BuildServiceProvider().GetRequiredService<IOptions<TOptions>>().Value;
    }
}
