using Common.Domain.SeedWork;
using Shared.Util.Extensions;

namespace SiopjModule.Domain.Entities;

public partial class ProgramaOperacional : IEntity
{
    private DateTime eTD;

    public ProgramaOperacional() {}

    public int NumeroAZ { get; private set; }
    public string IMO { get; private set; } = default!;
    public int Orden { get; private set; }
    public string Puesto { get; private set; } = default!;
    public int Anio { get; private set; }
    public int Semana { get; private set; }
    public DateTime ETA { get; private set; }
    public DateTime ETB { get; private set; }
    public DateTime ETC { get; private set; }
    public string? FechaCorta { get; private set; }
    public int? ContenedoresImpo { get; private set; }
    public int? ContenedoresExpo { get; private set; }
    public decimal? TonelajeImpo { get; private set; }
    public decimal? TonelajeExpo { get; private set; }
    public string? Equipo { get; private set; }
    public int CodigoModalidad { get; private set; }
    public int CodigoCliente { get; private set; }
    public int? CodigoEstibador { get; private set; }
    public string? PuertoInicial { get; private set; }
    public string? PuertoProcedencia { get; private set; }
    public string? PuertoDestino { get; private set; }
    public string? PuertoFinal { get; private set; }
    public string? LineaNaviera { get; private set; }
    public double? EstadiaEstimada { get; private set; }
    public decimal? CaladoProyectado { get; private set; }
    public string? Estado { get; private set; }
    public int? CantidadPaletas { get; private set; }
    public string? TipoCarga { get; private set; }
    public string? UsuarioAdiciona { get; private set; }
    public DateTime? FechaAdicion { get; private set; }
    public string? UsuarioModifica { get; private set; }
    public DateTime? FechaModifica { get; private set; }

    public ProgramaOperacional(
        int numeroAZ,
        string imo,
        DateTime eta,
        DateTime etb,
        DateTime etc,
        DateTime etd,
        int codigoCliente,
        int? codigoEstibador,
        string puertoInicial,
        string puertoProcedencia,
        string puertoDestino,
        string puertoFinal,
        string lineaNaviera,
        decimal caladoProyectado,
        string tipoCarga,
        int contenedoresImpo,
        int contenedoresExpo,
        decimal tonelajeImpo,
        decimal tonelajeExpo,
        string usuario,
        int codigoModalidad
    )
    {
        int week = eta.Date.WeekNumber();
        NumeroAZ = numeroAZ;
        Orden = 1;
        Puesto = "ANC";
        Anio = eta.Year;
        Semana = week;
        IMO = imo;
        ETA = eta;
        ETB = etb;
        ETC = etc;
        CodigoCliente = codigoCliente;
        CodigoEstibador = codigoEstibador ?? 9998;
        PuertoInicial = puertoInicial;
        PuertoProcedencia = puertoProcedencia;
        PuertoDestino = puertoDestino;
        PuertoFinal = puertoFinal;        
        LineaNaviera = lineaNaviera;
        EstadiaEstimada = (etd - eta).TotalHours;
        CaladoProyectado = caladoProyectado;
        TipoCarga = tipoCarga.ToUpper();
        ContenedoresImpo = contenedoresImpo;
        //CodigoModalidad = 14;
        CodigoModalidad = codigoModalidad;
        ContenedoresExpo = contenedoresExpo;
        TonelajeImpo = tonelajeImpo;
        TonelajeExpo = tonelajeExpo;
        CantidadPaletas = 0;
        UsuarioAdiciona = usuario;
        FechaAdicion = DateTime.Now;
    }

    public ProgramaOperacional(int numeroAz, string imo, DateTime eTA, DateTime eTB, DateTime eTC, DateTime eTD, int codigoCliente, int? codigoEstibador, string puertoInicial, string puertoProcedencia, string puertoDestino, string puertoFinal, string lineaNaviera, decimal caladoProyectado, string tipoCarga, int contenedoresImpo, int contenedoresExpo, decimal tonelajeImpo, decimal tonelajeExpo)
    {
        NumeroAZ = numeroAz;
        IMO = imo;
        ETA = eTA;
        ETB = eTB;
        ETC = eTC;
        this.eTD = eTD;
        CodigoCliente = codigoCliente;
        CodigoEstibador = codigoEstibador;
        PuertoInicial = puertoInicial;
        PuertoProcedencia = puertoProcedencia;
        PuertoDestino = puertoDestino;
        PuertoFinal = puertoFinal;
        LineaNaviera = lineaNaviera;
        CaladoProyectado = caladoProyectado;
        TipoCarga = tipoCarga;
        ContenedoresImpo = contenedoresImpo;
        ContenedoresExpo = contenedoresExpo;
        TonelajeImpo = tonelajeImpo;
        TonelajeExpo = tonelajeExpo;
    }

    public int GetArrivalNumber()
    {
        decimal a = ((decimal)NumeroAZ) / 10000;
        int b = NumeroAZ / 10000;
        decimal c = a - b;
        var d = c * 10000;

        return (int)d;
    }

    public void CambiarPuesto(string puesto)
    => Puesto = puesto;
}
