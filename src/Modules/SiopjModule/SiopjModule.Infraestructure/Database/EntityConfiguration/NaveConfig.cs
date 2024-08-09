using Microsoft.EntityFrameworkCore;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Infraestructure.Database.EntityConfiguration;

internal sealed class NaveConfig
: IEntityTypeConfiguration<Nave>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Nave> builder)
    {
        builder.ToTable("MAESTRO_NAVES");
        builder.HasKey(p => p.IMO);

        builder.Property(p => p.IMO).HasMaxLength(9).HasColumnName("NUM_REG_LLOYD");
        builder.Property(p => p.TipoNave).HasMaxLength(30).HasColumnName("TIPO_NAVE");
        builder.Property(p => p.Nombre).HasMaxLength(60).HasColumnName("NOM_NAVE");
        builder.Property(p => p.Senal).HasMaxLength(10).HasColumnName("SENAL");
        builder.Property(p => p.CodigoBandera).HasMaxLength(3).HasColumnName("COD_BANDERA");
        builder.Property(p => p.LineaNaviera).HasMaxLength(4).HasColumnName("LIN_NAVIERA");
        builder.Property(p => p.CodigoConferencia).HasColumnName("COD_CONFERENCIA");
        builder.Property(p => p.TRB).HasColumnName("TRB");
        builder.Property(p => p.TRN).HasColumnName("TRN");
        builder.Property(p => p.TPM).HasColumnName("TPM");
        builder.Property(p => p.Eslora).HasColumnName("ESLORA");
        builder.Property(p => p.Puntal).HasColumnName("PUNTAL");
        builder.Property(p => p.Manga).HasColumnName("MANGA");
        builder.Property(p => p.CaladoMaximo).HasColumnName("CAL_MAXIMO");
        builder.Property(p => p.CaladoMinimo).HasColumnName("CAL_MINIMO");
        builder.Property(p => p.Pisos).HasColumnName("PISOS");
        builder.Property(p => p.Escotillas).HasColumnName("ESCOTILLAS");
        builder.Property(p => p.Winches).HasColumnName("WINCHES");
        builder.Property(p => p.Plumas).HasColumnName("PLUMAS");
        builder.Property(p => p.Gruas).HasColumnName("GRUAS");
        builder.Property(p => p.Motores).HasColumnName("MOTORES");
        builder.Property(p => p.AnioConstruccion).HasColumnName("ANO_CONSTRUC");
        builder.Property(p => p.CapacidadContenedores).HasColumnName("CAP_CONT");
    }
}
