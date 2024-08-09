using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Common.Infraestructure.Database.Extensions;

public static class MigrationsExtensions
{
    public static IServiceCollection ExecuteMigrations<TDbContext>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) where TDbContext : DbContext
    {        
        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var serviceScope = scope.ServiceProvider;
            try
            {
                var context = serviceScope.GetRequiredService<TDbContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = serviceScope.GetRequiredService<ILogger<TDbContext>>();
                logger.LogError(ex, "An error occurred while migrating the database for {@Name}.", typeof(TDbContext).Name);
            }
        }
        return services;
    }    
}
