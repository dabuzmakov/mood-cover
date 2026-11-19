namespace MoodCover.Core.Registry;

public class NamedRegistry<T>
{
    private readonly Dictionary<string, T> _items;

    public NamedRegistry(IEnumerable<T> items, Func<T, string> getName)
    {
        _items = items.ToDictionary(getName, StringComparer.OrdinalIgnoreCase);
    }

    public T Get(string name)
    {
        if (_items.TryGetValue(name, out var item))
            return item;

        throw new ArgumentException($"Неизвестное имя: {name} для {typeof(T).Name}", nameof(name));
    }
}