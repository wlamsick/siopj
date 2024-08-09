namespace Microsoft.EntityFrameworkCore.Metadata.Builders;

public static class ColumnStandardPropertyBuilderExtensions
{
    public static PropertyBuilder<TProperty> UseColumnName<TProperty>(this PropertyBuilder<TProperty> propertyBuilder) {
        return propertyBuilder.HasMaxLength(100);
    }

    /* public static ComplexTypePropertyBuilder<TProperty> UseColumnName<TProperty>(this ComplexTypePropertyBuilder<TProperty> propertyBuilder) {
        return propertyBuilder.HasMaxLength(100);
    } */

    public static PropertyBuilder<TProperty> UseColumnDescription<TProperty>(this PropertyBuilder<TProperty> propertyBuilder) {
        return propertyBuilder.HasMaxLength(500);
    }

    public static PropertyBuilder<TProperty> UseEmailStandardSize<TProperty>(this PropertyBuilder<TProperty> propertyBuilder) {
        return propertyBuilder.HasMaxLength(360);
    }

    /* public static ComplexTypePropertyBuilder UseEmailStandardSize<TProperty>(this ComplexTypePropertyBuilder<TProperty> propertyBuilder) {
        return propertyBuilder.HasMaxLength(360);
    } */
}   
