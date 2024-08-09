using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiopjModule.Domain.Entities;

namespace SiopjModule.Infraestructure.Database.EntityConfiguration;

internal sealed class ClienteConfig
: IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("CLIENTES");
        builder.HasKey(p => p.Codigo);

        builder.Property(p => p.Codigo).HasColumnName("COD_CLIENTE");
        builder.Property(p => p.Nombre).HasMaxLength(200).HasColumnName("NOM_CLIENTE");
        builder.Property(p => p.CedulaJuridica).HasColumnName("NUM_CED_JURIDICA");
    }
}
