using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SiopjModule.Infraestructure.Database;
using MassTransit.Orchestrator;
using Shared.Contracts.Siopj;
using MassTransit;
using SiopjModule.Infraestructure.Orchestation.Consumers;
using Microsoft.Extensions.Hosting;

namespace SiopjModule.Infraestructure;

public static class DependecyInjection
{

    public static IHostBuilder ConfigureInfraestructure(this IHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
            services.AddMediatR(r => r.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.ConfigureDatabase(context.Configuration);
        });
        return builder;
    }
    
    public static WebApplicationBuilder ConfigureInfraestructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(r => r.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        builder.Services.ConfigureDatabase(builder.Configuration);
        return builder;
    }

    public static IHostBuilder ConfigureOrchestator(this IHostBuilder builder)
    {
        var assemby = Assembly.GetExecutingAssembly();
        builder.UseRabbitMQOrchestator(entryAssembly: assemby,
        (context, cfg) =>
        {            
            /* cfg.Publish<UserCreatedMessage>(cfg =>
            {                
                cfg.Durable = true;
                cfg.ExchangeType = ExchangeType.Fanout;
                cfg.AutoDelete = false;
            }); */

            cfg.ReceiveEndpoint(ExchangeName.QueueName<RegistrarArriboConsumer, RegistrarArriboMessage>(), x =>
            {
                x.ConfigureConsumer<RegistrarArriboConsumer>(context);
            });

            cfg.ReceiveEndpoint(ExchangeName.QueueName<ActualizarImoConsumer, ActualizarImoMessage>(), x =>
            {
                x.ConfigureConsumer<ActualizarImoConsumer>(context);
            });

            cfg.ReceiveEndpoint(ExchangeName.QueueName<RegistrarNaveLlegadaPuertoConsumer, RegistrarNaveLlegadaPuertoMessage>(), x =>
            {
                x.ConfigureConsumer<RegistrarNaveLlegadaPuertoConsumer>(context);
            });

            cfg.ReceiveEndpoint(ExchangeName.QueueName<RegistrarMarcaAtraqueConsumer, RegistrarMarcaAtraqueMessage>(), x =>
            {
                x.ConfigureConsumer<RegistrarMarcaAtraqueConsumer>(context);
            });
        });
        
        return builder;
    }
}
