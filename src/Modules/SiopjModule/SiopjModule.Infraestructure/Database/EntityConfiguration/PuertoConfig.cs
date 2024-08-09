using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Infraestructure.Database.EntityConfiguration;

internal sealed class PuertoConfig
: IEntityTypeConfiguration<Puerto>
{
    public void Configure(EntityTypeBuilder<Puerto> builder)
    {
        builder.ToTable("PUERTOS");
        builder.HasKey(p => p.CodigoAduana);

        builder.Property(p => p.CodigoAduana).HasMaxLength(6).HasColumnName("COD_PTO_ADUN");
        builder.Property(p => p.CodigoPuerto).HasMaxLength(6).HasColumnName("COD_PUERTO");
        builder.Property(p => p.Descripcion).HasMaxLength(50).HasColumnName("DESC_PUERTO");
        builder.Property(p => p.Pais).HasMaxLength(50).HasColumnName("PAIS");
    }
}
