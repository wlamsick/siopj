using Common.Domain.SeedWork;

namespace SiopjModule.Domain.Entities;

public class NaveLlegadaPuerto : IEntity
{
    public NaveLlegadaPuerto()
    {

    }

    public NaveLlegadaPuerto(
        int numeroAZ)
    {
        NumeroAZ = numeroAZ;
        CaladoLlegadaProa = 0;
        CaladoLlegadaPopa = 0;
        CaladoSalidaProa = 0;
        CaladoSalidaPopa = 0;
        FechaAdiciona = DateTime.Now;
        UsuarioAdiciona = "Japdeva PLS";
    }

    public int NumeroAZ { get; private set; }    
    public decimal CaladoLlegadaProa { get; private set; }
    public decimal CaladoLlegadaPopa { get; private set; }
    public decimal CaladoSalidaProa { get; private set; }
    public decimal CaladoSalidaPopa { get; private set; }
    public DateTime FechaAdiciona { get; private set; }
    public string UsuarioAdiciona { get; private set; } = default!;
}
