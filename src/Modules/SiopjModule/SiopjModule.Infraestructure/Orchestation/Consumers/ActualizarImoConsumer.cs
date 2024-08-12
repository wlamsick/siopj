using MassTransit;
using MassTransit.Orchestrator;
using Microsoft.Extensions.Logging;
using Shared.Contracts.Siopj;
using SiopjModule.Domain.Entities;
using SiopjModule.Domain.Repositories;

namespace SiopjModule.Infraestructure.Orchestation.Consumers;

public sealed class ActualizarImoConsumer
: IMessageConsumer<ActualizarImoMessage>
{
    private readonly INaveRepository repository;
    private readonly ILogger<ActualizarImoConsumer> logger;
    
    public ActualizarImoConsumer(
        INaveRepository repository,
        ILogger<ActualizarImoConsumer> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task Consume(ConsumeContext<ActualizarImoMessage> context)
    {
        var message = context.Message;

        var nave = await repository.GetAsync(p => p.IMO == message.IMO);

        if (nave is null)
        {
            nave = new Nave(
                message.IMO,
                message.TipoNave,
                message.Nombre,
                message.CodigoBandera,
                message.CaladoMaximo,
                message.Eslora,
                message.TRB,
                message.TRN,
                message.TPM
            );

            repository.Insert(nave);
        } else {
            nave.Update(
                message.TipoNave,
                message.Nombre,
                message.CodigoBandera,
                message.CaladoMaximo,
                message.Eslora,
                message.TRB,
                message.TRN,
                message.TPM
            );
        }

        try
        {
            await repository.UnitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al actualizar la nave");
            throw;
        }
    }
}
