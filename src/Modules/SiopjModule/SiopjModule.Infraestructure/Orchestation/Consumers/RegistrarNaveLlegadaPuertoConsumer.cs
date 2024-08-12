using MassTransit;
using MassTransit.Orchestrator;
using Microsoft.Extensions.Logging;
using Shared.Contracts.Siopj;
using SiopjModule.Domain.Entities;
using SiopjModule.Domain.Repositories;

namespace SiopjModule.Infraestructure.Orchestation.Consumers;

public sealed class RegistrarNaveLlegadaPuertoConsumer
: IMessageConsumer<RegistrarNaveLlegadaPuertoMessage>
{
    private readonly INaveLlegadaPuertoRepository repository;
    ILogger<RegistrarNaveLlegadaPuertoConsumer> logger;

    public RegistrarNaveLlegadaPuertoConsumer(
        INaveLlegadaPuertoRepository repository,
        ILogger<RegistrarNaveLlegadaPuertoConsumer> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }
    public async Task Consume(ConsumeContext<RegistrarNaveLlegadaPuertoMessage> context)
    {
        var message = context.Message;
        
        if (repository.Exists(p => p.NumeroAZ == message.NumeroAZ))
        {
            logger.LogWarning("La llegada con el número AZ {NumeroAZ} ya ha sido registrada", message.NumeroAZ);
            return;
        }

        var llegada = new NaveLlegadaPuerto(message.NumeroAZ);

        try
        {
            repository.Insert(llegada);
            await repository.UnitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al guardar la llegada de la nave");
            throw;
        }
    }
}
