using Common.Domain.SeedWork;

namespace SiopjModule.Domain.Entities;

public class MarcaAtraque : IEntity
{
    public MarcaAtraque() {}

    public MarcaAtraque(
        int numeroAZ,
        DateTime fecha,        
        string puesto,
        int codigoOperacion
    )
    {
        NumeroAzProv = NumeroAZ = numeroAZ;
        Turno = 1;
        FechaHoraMarca = fecha;
        Puesto = puesto;
        Orden = 1;
        CodigoOperacion = codigoOperacion;
    }

    public int NumeroAZ { get; private set; }
    public DateTime FechaHoraMarca { get; private set; }
    public int NumeroAzProv { get; private set; }
    public int Turno { get; private set; }
    public string Puesto { get; private set; } = default!;
    public int CodigoOperacion { get; private set; }
    public int Orden { get; private set; }

    public void Update(
        DateTime fecha,    
        string puesto,
        int codigoOperacion
    )
    {
        Turno = 1;
        FechaHoraMarca = fecha;
        Puesto = puesto;
        Orden = 1;
        CodigoOperacion = codigoOperacion;
    }
}
