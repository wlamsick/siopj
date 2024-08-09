using AutoMapper;
using System.Reflection;

namespace Common.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        foreach (var assembly in assemblies)
        {
            ApplyMappingsFromAssembly(assembly);
        }
        //ApplyMappingsFromAssembly(Assembly.GetCallingAssembly());
    }

    private static readonly List<Assembly> assemblies = new();

    public static void RegisterAssembly(Assembly assembly)
    {
        assemblies.Add(assembly);
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();


        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}
