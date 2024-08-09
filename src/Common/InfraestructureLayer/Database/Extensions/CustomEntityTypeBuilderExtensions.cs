using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Common.Infraestructure.Database.Extensions;

public static class CustomEntityTypeBuilderExtensions
{
    public static EntityTypeBuilder<T> ToSchema<T>(this EntityTypeBuilder<T> builder, string schema) where T : class
    {
        builder.Metadata.SetSchema(schema);
        return builder;        
    }
}
