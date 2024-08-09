using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Infraestructure.Database.EntityConfiguration;

internal sealed class ProgramaOperacionalConfig
: IEntityTypeConfiguration<ProgramaOperacional>
{
    public void Configure(EntityTypeBuilder<ProgramaOperacional> builder)
    {
        builder.ToTable("PROG_OPERACIONES");
        builder.HasKey(x => new {x.NumeroAZ, x.Orden});

        builder.Property(p => p.NumeroAZ).HasColumnName("NUM_AZ_PROV");
        builder.Property(p => p.Orden).HasColumnName("ORDEN");
        builder.Property(p => p.IMO).HasMaxLength(8).HasColumnName("NUM_REG_LLOYD");
        builder.Property(p => p.Puesto).HasColumnName("PUESTO").HasMaxLength(10);
        builder.Property(p => p.Anio).HasColumnName("ANO");
        builder.Property(p => p.Semana).HasColumnName("SEMANA");
        builder.Property(p => p.ETA).HasColumnName("FECHA_HORA_ETA");
        builder.Property(p => p.ETB).HasColumnName("FECHA_HORA_INICIO");
        builder.Property(p => p.ETC).HasColumnName("FECHA_HORA_FIN");
        builder.Property(p => p.FechaCorta).HasColumnName("FECHA_CORTA").HasMaxLength(8);
        builder.Property(p => p.ContenedoresImpo).HasColumnName("CANT_CONT_IMPO");
        builder.Property(p => p.ContenedoresExpo).HasColumnName("CANT_CONT_EXPO");
        builder.Property(p => p.TonelajeImpo).HasColumnName("TON_IMPO");
        builder.Property(p => p.TonelajeExpo).HasColumnName("TON_EXPO");
        builder.Property(p => p.Equipo).HasColumnName("EQ_UTILIZAR").HasMaxLength(15);
        builder.Property(p => p.CodigoModalidad).HasColumnName("COD_MODALIDAD");
        builder.Property(p => p.CodigoCliente).HasColumnName("COD_CLIENTE");
        builder.Property(p => p.CodigoEstibador).HasColumnName("COD_ESTIBADOR");
        builder.Property(p => p.PuertoInicial).HasColumnName("PTO_INICIAL").HasMaxLength(6);
        builder.Property(p => p.PuertoProcedencia).HasColumnName("PTO_PROCED").HasMaxLength(6);
        builder.Property(p => p.PuertoDestino).HasColumnName("PTO_DEST").HasMaxLength(6);
        builder.Property(p => p.PuertoFinal).HasColumnName("PTO_FINAL").HasMaxLength(6);
        builder.Property(p => p.LineaNaviera).HasColumnName("LIN_NAVIERA").HasMaxLength(8);
        builder.Property(p => p.EstadiaEstimada).HasColumnName("ESTAD_ESTIMADA");
        builder.Property(p => p.CaladoProyectado).HasColumnName("CALAD_PROYECT");
        builder.Property(p => p.Estado).HasColumnName("ESTADO").HasMaxLength(10);
        builder.Property(p => p.CantidadPaletas).HasColumnName("PALETAS");
        builder.Property(p => p.TipoCarga).HasColumnName("TIPO_CARGA").HasMaxLength(25);
        builder.Property(p => p.UsuarioAdiciona).HasColumnName("USUARIO_ADICIONA").HasMaxLength(50);
        builder.Property(p => p.FechaAdicion).HasColumnName("FEC_ADICIONA");
        builder.Property(p => p.UsuarioModifica).HasColumnName("USUARIO_MODIF").HasMaxLength(50);
        builder.Property(p => p.FechaModifica).HasColumnName("FEC_MODIFICADO");
    }
}
