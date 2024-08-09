using Common.Domain.SeedWork;

namespace SiopjModule.Domain.Entities;

public partial class Nave : IEntity
{
    public Nave() { }
    
    public Nave(
        string imo,
        string tipoNave,
        string nombre,
        string codigoBandera,
        decimal caladoMaximo,
        decimal eslora,
        decimal trb,
        decimal tpn,
        decimal tpm
    )
    {
        IMO = imo;
        TipoNave = tipoNave;
        Nombre = nombre;
        CodigoBandera = codigoBandera;
        Eslora = eslora;
        CaladoMaximo = caladoMaximo;
        TRB = trb;
        TRN = tpn;
        TPM = tpm;
    }
    
    public string IMO { get; private set; } = default!;
    public string TipoNave { get; private set; } = default!;
    public string Nombre { get; private set; } = default!;
    public string? Senal { get; private set; }
    public string? CodigoBandera { get; private set; }
    public string? LineaNaviera { get; private set; }
    public int CodigoConferencia { get; private set; }
    public decimal TRB { get; private set; }
    public decimal TRN { get; private set; }
    public decimal? TPM { get; private set; }
    public decimal Eslora { get; private set; }
    public decimal? Puntal { get; private set; }
    public decimal? Manga { get; private set; }
    public decimal? CaladoMaximo { get; private set; }
    public decimal? CaladoMinimo { get; private set; }
    public int? Pisos { get; private set; }
    public int? Escotillas { get; private set; }
    public int? Winches { get; private set; }
    public int? Plumas { get; private set; }
    public int? Gruas { get; private set; }
    public int? Motores { get; private set; }
    public int? AnioConstruccion { get; private set; }
    public int? CapacidadContenedores { get; private set; }

    
    
    public void Update(        
        string tipoNave,
        string nombre,
        string codigoBandera,
        decimal caladoMaximo,
        decimal eslora,
        decimal trb,
        decimal tpn,
        decimal tpm
    )
    {        
        TipoNave = tipoNave;
        Nombre = nombre;
        CodigoBandera = codigoBandera;
        Eslora = eslora;
        CaladoMaximo = caladoMaximo;
        TRB = trb;
        TRN = tpn;
        TPM = tpm;
    }
}
