using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiopjModule.Domain.Entities;
using SiopjModule.Domain.Repositories;
using SiopjModule.Infraestructure.Database.Repository;

namespace SiopjModule.Infraestructure.Database;

public static class DatabaseDependencyInjection
{
    internal static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<INaveRepository, NaveRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<INaveLlegadaPuertoRepository, NaveLlegadaPuertoRepository>();
        services.AddScoped<IMarcaAtraqueRepository, MarcaAtraqueRepository>();
        services.AddScoped<IProgramaOperacionalRepository, ProgramaOperacionalRepository>();
        services.AddScoped<IPuertoRepository, PuertoRepository>();
        
        services.AddDbContext<SiopjContext>((sp, options) =>
        {
            options.UseOracle(configuration.GetConnectionString("SiopjDatabase"));
        });


        return services;
    }
}
