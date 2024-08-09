using System.Reflection;
using Common.Domain.Services;
using MassTransit.Orchestrator.Configuration;
using MassTransit.Orchestrator.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace MassTransit.Orchestrator;

public static class DependencyInjection
{
    public static WebApplicationBuilder UseRabbitMQOrchestator(
        this WebApplicationBuilder builder,
        Assembly[] assemblies,
        Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> configuration,
        string sectionName = "RabbitMQ")
    {
        builder.Services.AddScoped<IEventBus, MassTransitMessageOrchestrator>();

        var config = builder.Configuration.GetSection(sectionName) ?? throw new InvalidOperationException($"Section {sectionName} not found in configuration");

        builder.Services.Configure<OrchestatorSettings>(
            builder.Configuration.GetSection(sectionName)
        );

        builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<OrchestatorSettings>>().Value);

        builder.Services.AddMassTransit(bus =>
        {
            bus.AddConsumers(assemblies);
            bus.AddRequestClients(assemblies);                   

            bus.UsingRabbitMq((context, cfg) =>
            {
                var config = context.GetRequiredService<OrchestatorSettings>();

                cfg.Host(new Uri(config.Host), config.ConnectionName, h =>
                {
                    h.Username(config.Username);
                    h.Password(config.Password);
                });

                configuration(context, cfg);
            });
        });

        return builder;
    }

    public static WebApplicationBuilder UseRabbitMQOrchestator(
        this WebApplicationBuilder builder,
        Assembly entryAssembly,
        Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> configuration,
        string sectionName = "RabbitMQ")
    {        
        return builder.UseRabbitMQOrchestator(new[] { entryAssembly }, configuration, sectionName);
    }


    public static HostApplicationBuilder UseRabbitMQOrchestator(
        this HostApplicationBuilder builder,
        Assembly entryAssembly,
        Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> configuration,
        string sectionName = "RabbitMQ")
    {
        builder.Services.AddScoped<IEventBus, MassTransitMessageOrchestrator>();

        var config = builder.Configuration.GetSection(sectionName) ?? throw new InvalidOperationException($"Section {sectionName} not found in configuration");

        builder.Services.Configure<OrchestatorSettings>(
            builder.Configuration.GetSection(sectionName)
        );

        builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<OrchestatorSettings>>().Value);

        builder.Services.AddMassTransit(bus =>
        {
            bus.AddConsumers(entryAssembly);

            bus.UsingRabbitMq((context, cfg) =>
            {
                var config = context.GetRequiredService<OrchestatorSettings>();

                cfg.Host(new Uri(config.Host), config.ConnectionName, h =>
                {
                    h.Username(config.Username);
                    h.Password(config.Password);
                });

                configuration(context, cfg);
            });
        });

        return builder;
    }
}
