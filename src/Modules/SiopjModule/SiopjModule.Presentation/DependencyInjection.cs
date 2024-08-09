using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace SiopjModule.Presentation;

public static class DependencyInjection
{
    public static WebApplicationBuilder ConfigureEndpoints(this WebApplicationBuilder builder)
    {
        builder.UseDefaultVersioning();

        builder.Services.AddCookiePolicy(cfg =>
        {
            cfg.MinimumSameSitePolicy = SameSiteMode.Strict;
            cfg.Secure = CookieSecurePolicy.Always;
            cfg.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
        });

        /* builder.Services
                .AddAuthentication()
                .AddBearerToken(options => {
                    
                });
        builder.Services.AddAuthorization(); */
        //builder.Services.AddJwtToken(); 

        return builder;
    }
}
