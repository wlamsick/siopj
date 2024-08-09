using System.Reflection;
using Common.Application.Mapping;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Application.DependencyInjection;

public static class CommonServices
{
    public static IServiceCollection AddDefaultServices(this IServiceCollection services,
    string language = "en")
    {
        var assembly = Assembly.GetCallingAssembly();
        services.AddMediatR(opt => opt.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);

        MappingProfile.RegisterAssembly(assembly);

        ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo(language);

        services.AddAutoMapper(options =>
        {
            options.AddProfile(new MappingProfile());
        }, Array.Empty<Assembly>());

        return services;
    }
}
