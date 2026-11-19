namespace MoodCover.Core.Fractal_Flame.Palettes;

public sealed class PaletteFactory : IPaletteFactory
{
    private readonly Dictionary<string, IPalette> _registeredPalettes;

    public PaletteFactory(params IPalette[] palettes)
    {
        _registeredPalettes = palettes.ToDictionary(
            palette => palette.Name,
            StringComparer.OrdinalIgnoreCase);
    }

    public IPalette Get(string name)
    {
        if (_registeredPalettes.TryGetValue(name, out var palette))
            return palette;

        throw new ArgumentException($"Неизвестная палитра: {name}", nameof(name));
    }
}