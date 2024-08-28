using MassTransit;
using MassTransit.Orchestrator;
using Microsoft.Extensions.Logging;
using Shared.Contracts.Siopj;
using SiopjModule.Domain.Entities;
using SiopjModule.Domain.Repositories;

namespace SiopjModule.Infraestructure.Orchestation.Consumers;

public sealed class RegistrarArriboConsumer
: IMessageConsumer<RegistrarArriboMessage>
{
    private readonly IProgramaOperacionalRepository _progOperaciones;
    private readonly ILogger<RegistrarArriboConsumer> _logger;
    private readonly IClienteRepository _clientes;

    public RegistrarArriboConsumer(
        IProgramaOperacionalRepository repository,
        IClienteRepository clientes,
        ILogger<RegistrarArriboConsumer> logger)
    {
        this._progOperaciones = repository;
        this._logger = logger;
        this._clientes = clientes;
    }

    public async Task Consume(ConsumeContext<RegistrarArriboMessage> context)
    {
        var message = context.Message;
        Cliente? naviero;
        Cliente? estibador = null;

        if (long.TryParse(message.IdentificacionNaviero, out long cedulaJuridica))
        {
            naviero = await _clientes.GetAsync(p => p.CedulaJuridica == cedulaJuridica);

            if (naviero is null)
            {
                var codCliente = _clientes.UltimoCodigo() + 1;

                naviero = Cliente.RegistrarNaviero(codCliente, message.Naviero, cedulaJuridica);
                _clientes.Insert(naviero);
                await _clientes.UnitOfWork.SaveChangesAsync();
            }
        }
        else
        {
            _logger.LogWarning("Invalid Naviero identification {IdentificacionNaviero}", message.IdentificacionNaviero);
            return;
        }

        if (!string.IsNullOrWhiteSpace(message.IdentificacionEstibador))
        {
            if (long.TryParse(message.IdentificacionEstibador, out cedulaJuridica))
            {
                estibador = await _clientes.GetAsync(p => p.CedulaJuridica == cedulaJuridica);

                if (estibador is null)
                {
                    var codCliente = _clientes.UltimoCodigo() + 1;

                    estibador = Cliente.RegistrarEstibador(codCliente, message.Estibador!, cedulaJuridica);
                    _clientes.Insert(estibador);
                    await _clientes.UnitOfWork.SaveChangesAsync();
                }
            }
            else
            {
                _logger.LogWarning("Invalid Estibador identification {IdentificacionEstibador}", message.IdentificacionEstibador);
                return;
            }
        }

        var programa = await _progOperaciones.GetAsync(p => p.NumeroAZ == message.NumeroAZ && p.Orden == 1);

        if (programa != null)
        {
            programa.Update(
                numeroAZ: message.NumeroAZ,
                imo: message.IMO,
                eta: message.ETA,
                etb: message.ETB,
                etc: message.ETC,
                etd: message.ETD,
                codigoCliente: naviero.Codigo,
                codigoEstibador: estibador?.Codigo,
                puertoInicial: message.PuertoInicial,
                puertoProcedencia: message.PuertoProcedencia,
                puertoDestino: message.PuertoDestino,
                puertoFinal: message.PuertoFinal,
                lineaNaviera: "9999",
                caladoProyectado: message.CaladoProyectado,
                tipoCarga: message.TipoCarga,
                contenedoresImpo: 0,
                contenedoresExpo: 0,
                tonelajeImpo: 0,
                tonelajeExpo: 0,
                usuario: "japdeva-pls",
                codigoModalidad: message.CodigoModalidad
            );
        }
        else
        {
            programa = new(
                numeroAZ: message.NumeroAZ,
                imo: message.IMO,
                eta: message.ETA,
                etb: message.ETB,
                etc: message.ETC,
                etd: message.ETD,
                codigoCliente: naviero.Codigo,
                codigoEstibador: estibador?.Codigo,
                puertoInicial: message.PuertoInicial,
                puertoProcedencia: message.PuertoProcedencia,
                puertoDestino: message.PuertoDestino,
                puertoFinal: message.PuertoFinal,
                lineaNaviera: "9999",
                caladoProyectado: message.CaladoProyectado,
                tipoCarga: message.TipoCarga,
                contenedoresImpo: 0,
                contenedoresExpo: 0,
                tonelajeImpo: 0,
                tonelajeExpo: 0,
                usuario: "japdeva-pls",
                codigoModalidad: message.CodigoModalidad
            );

            _progOperaciones.Insert(programa);
        }

        try
        {
            await _progOperaciones.UnitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating Programa Operacional {NumeroAz}", message.NumeroAZ);
            throw new Exception("Error creating Programa Operacional", ex);
        }
    }
}
