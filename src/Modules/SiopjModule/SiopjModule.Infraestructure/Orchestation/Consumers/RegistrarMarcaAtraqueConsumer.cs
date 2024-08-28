using MassTransit;
using MassTransit.Orchestrator;
using Microsoft.Extensions.Logging;
using Shared.Contracts.Siopj;
using SiopjModule.Domain.Entities;
using SiopjModule.Domain.Repositories;

namespace SiopjModule.Infraestructure.Orchestation.Consumers;

public sealed class RegistrarMarcaAtraqueConsumer
: IMessageConsumer<RegistrarMarcaAtraqueMessage>
{
    private readonly IMarcaAtraqueRepository repository;
    private readonly ILogger<RegistrarMarcaAtraqueConsumer> logger;
    private readonly IProgramaOperacionalRepository programaOperacionalRepository;

    public RegistrarMarcaAtraqueConsumer(
        IMarcaAtraqueRepository repository,
        IProgramaOperacionalRepository programaOperacionalRepository,
        ILogger<RegistrarMarcaAtraqueConsumer> logger)
    {
        this.repository = repository;
        this.logger = logger;
        this.programaOperacionalRepository = programaOperacionalRepository;
    }

    public async Task Consume(ConsumeContext<RegistrarMarcaAtraqueMessage> context)
    {
        var message = context.Message;

        var programa = await programaOperacionalRepository.GetAsync(p => p.NumeroAZ == message.NumeroAZ);

        if (programa is null)
        {
            logger.LogWarning("No se encontró en el programa operacional el Número de AZ {NumeroAz}", message.NumeroAZ);
            return;
        }

        programa.CambiarPuesto(message.Puesto);

        var atraque = await  repository.GetAsync(p => p.NumeroAZ == message.NumeroAZ && p.CodigoOperacion == 3);

        var desatraque = await  repository.GetAsync(p => p.NumeroAZ == message.NumeroAZ && p.CodigoOperacion == 4);

        if (atraque is not null)
        {
            atraque.Update(
                fecha: message.FechaAtraque,
                puesto: message.Puesto,
                codigoOperacion: 3
            );
        }
        else
        {
            atraque = new MarcaAtraque(
                numeroAZ: message.NumeroAZ,
                fecha: message.FechaAtraque,
                puesto: message.Puesto,
                codigoOperacion: 3
            );

            repository.Insert(atraque);
        }

        if (desatraque is not null)
        {
            desatraque.Update(
                fecha: message.FechaDesatraque,
                puesto: message.Puesto,
                codigoOperacion: 4
            );
        }
        else
        {
            desatraque = new MarcaAtraque(
                numeroAZ: message.NumeroAZ,
                fecha: message.FechaDesatraque,
                puesto: message.Puesto,
                codigoOperacion: 4
            );

            repository.Insert(desatraque);
        }

        try
        {
            await repository.UnitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error registrando marca de atraque {NumeroAz}", message.NumeroAZ);
            throw;
        }
    }
}
