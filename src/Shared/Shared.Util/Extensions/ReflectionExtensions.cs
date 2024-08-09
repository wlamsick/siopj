using System.Reflection;

namespace Shared.Util.Extensions;

public static class ReflectionExtensions
{
    public static bool PropertyExists(this object obj, string name)
    {
        return obj.GetType().GetPropertyInformation(name) != null;
    }

    public static PropertyInfo? GetPropertyInformation(this object obj, string name)
    {
        PropertyInfo? info = null;

        foreach (string part in name.Split('.'))
        {
            if (obj == null) { return null; }

            Type type = obj.GetType();
            info = type.GetProperty(part);
            if (info == null) { return null; }
        }

        return info;
    }

    public static Object? GetPropertyValue(this Object? obj, string name)
    {
        foreach (string part in name.Split('.'))
        {
            if (obj == null) { return null; }

            Type type = obj.GetType();
            PropertyInfo? info = type.GetProperty(part);
            if (info == null) { return null; }

            obj = info.GetValue(obj, null);
        }
        return obj;
    }    

    public static T? GetPropertyValue<T>(this Object obj, string name)
    {
        Object? retval = GetPropertyValue(obj, name);
        if (retval == null) { return default(T); }

        // throws InvalidCastException if types are incompatible
        return (T)retval;
    }

    public static bool TryGetPropertyValue<T>(this Object obj, string name, out T? value)
    {
        value = default(T);
        Object? retval = GetPropertyValue(obj, name);
        if (retval == null) { return false; }

        if (retval is T) { value = (T)retval; return true; }

        return false;
    }
}
