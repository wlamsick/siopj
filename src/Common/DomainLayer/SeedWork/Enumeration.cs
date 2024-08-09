using System.Reflection;

namespace Common.Domain.SeedWork;

public class Enumeration<T> where T : notnull
{
    protected Enumeration() { }

    protected Enumeration(T id, string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        Id = id;
        Name = name;
    }

    public T Id { get; private set; } = default!;
    public string Name { get; protected set; } = default!;


    public override int GetHashCode() => Id!.GetHashCode();

    public static IEnumerable<E> GetAll<E>() where E : Enumeration<T>
    {
        var fields = typeof(E).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        return fields.Select(f => f.GetValue(null)).Cast<E>();
    }

    public override string ToString() => Name;


    public static E? FromValue<E>(T value) where E : Enumeration<T>
    {
        var matchingItem = Parse<E, T>(value, "value", item => item.Id.Equals(value));
        return matchingItem;
    }

    public static E? FromDisplayName<E>(string displayName) where E : Enumeration<T>
    {
        var matchingItem = Parse<E, string>(displayName, "display name", item => item.Name == displayName);
        return matchingItem;
    }

    public bool Exists<E>(T value) where E : Enumeration<T>
    {
        var matchingItem = Parse<E, T>(value, "value", item => item.Id.Equals(value));
        return false;
    }

    private static E? Parse<E, K>(K value, string description, Func<E, bool> predicate) where E : Enumeration<T>
    {
        var matchingItem = GetAll<E>().FirstOrDefault(predicate); //?? throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(E)}");
        return matchingItem;
    }

}
