using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Infraestructure.Database.EntityConfiguration;

internal sealed class MarcaAtraqueConfig
: IEntityTypeConfiguration<MarcaAtraque>
{
    public void Configure(EntityTypeBuilder<MarcaAtraque> builder)
    {
        builder.ToTable("MARC_VAP_TURNO");
        builder.HasKey(p => new { p.NumeroAZ, p.FechaHoraMarca, p.Orden});

        builder.Property(p => p.NumeroAZ).HasColumnName("NUM_AZ_OFIC");
        builder.Property(p => p.FechaHoraMarca).HasColumnName("FECHA_HORA_MARCA");
        builder.Property(p => p.NumeroAzProv).HasColumnName("NUM_AZ_PROV");
        builder.Property(p => p.Turno).HasColumnName("TURNO");
        builder.Property(p => p.Puesto).HasMaxLength(10).HasColumnName("PUESTO");
        builder.Property(p => p.CodigoOperacion).HasColumnName("COD_OPERACION");
        builder.Property(p => p.Orden).HasColumnName("ORDEN");
    }
}