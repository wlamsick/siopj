using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Infraestructure.Database.EntityConfiguration;

internal class NaveLlegadaPuertoConfig
: IEntityTypeConfiguration<NaveLlegadaPuerto>
{
    public void Configure(EntityTypeBuilder<NaveLlegadaPuerto> builder)
    {
        builder.ToTable("NAVES_LLEGADAS_PUERTO");
        builder.HasKey(p => p.NumeroAZ);

        builder.Property(p => p.NumeroAZ).HasColumnName("NUM_AZ_OFIC");
        builder.Property(p => p.CaladoLlegadaProa).HasColumnName("CAL_LLEGADA_PROA");
        builder.Property(p => p.CaladoLlegadaPopa).HasColumnName("CAL_LLEGADA_POPA");
        builder.Property(p => p.CaladoSalidaProa).HasColumnName("CAL_SALIDA_PROA");
        builder.Property(p => p.CaladoSalidaPopa).HasColumnName("CAL_SALIDA_POPA");
        builder.Property(p => p.FechaAdiciona).HasColumnName("FEC_ADICIONA");
        builder.Property(p => p.UsuarioAdiciona).HasMaxLength(50).HasColumnName("USUARIO_ADICIONA");
    }
}
