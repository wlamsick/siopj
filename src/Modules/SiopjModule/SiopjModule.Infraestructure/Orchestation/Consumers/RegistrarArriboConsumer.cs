using MassTransit;
using MassTransit.Orchestrator;
using Microsoft.Extensions.Logging;
using Shared.Contracts.Siopj;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Infraestructure.Orchestation.Consumers;

public sealed class RegistrarArriboConsumer
: IMessageConsumer<RegistrarArriboMessage>
{
    private readonly IProgramaOperacionalRepository repository;
    private readonly ILogger<RegistrarArriboConsumer> logger;
    
    public RegistrarArriboConsumer(
        IProgramaOperacionalRepository repository,
        ILogger<RegistrarArriboConsumer> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task Consume(ConsumeContext<RegistrarArriboMessage> context)
    {
        var message = context.Message;

        var exists = await repository.ExistsAsync(p => p.NumeroAZ == message.NumeroAz);
        if (exists)
        {
            logger.LogWarning("Programa Operacional {NumeroAz} already exists", message.NumeroAz);
            return;
        }

        ProgramaOperacional programa = new(
            numeroAZ: message.NumeroAz,
            imo: message.Imo,
            eta: message.ETA,
            etb: message.ETB,
            etc: message.ETC,
            etd: message.ETD,
            codigoCliente: message.CodigoCliente,
            codigoEstibador: message.CodigoEstibador,
            puertoInicial: message.PuertoInicial,
            puertoProcedencia: message.PuertoProcedencia,
            puertoDestino: message.PuertoDestino,
            puertoFinal: message.PuertoFinal,
            lineaNaviera: "9999",
            caladoProyectado: message.CaladoProyectado,
            tipoCarga: message.TipoCarga,
            contenedoresImpo: message.ContenedoresImpo,
            contenedoresExpo: message.ContenedoresExpo,
            tonelajeImpo: message.TonelajeImpo,
            tonelajeExpo: message.TonelajeExpo,
            usuario: message.Usuario,
            codigoModalidad: message.CodigoModalidad
        );
        
        repository.Insert(programa);

        try
        {
            await repository.UnitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating Programa Operacional {NumeroAz}", message.NumeroAz);
            return;
        }        
    }
}
