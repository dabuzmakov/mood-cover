namespace MoodCover.Core.Fractal_Flame.Palettes;

public class GradientPalette : IPalette
{
    private readonly Color[] _colors;

    public string Name { get; }

    public GradientPalette(string name, params Color[] colors)
    {
        if (colors.Length == 0)
            throw new ArgumentException("Палитра должна содержать хотя бы один цвет.", nameof(colors));

        Name = name;
        _colors = colors.ToArray();
    }

    public Color Get(double coordinate)
    {
        if (coordinate is not (>= 0.0 and <= 1.0))
            throw new ArgumentOutOfRangeException(nameof(coordinate));

        var position = coordinate * (_colors.Length - 1);
        var leftIndex = (int)position;
        var rightIndex = Math.Min(leftIndex + 1, _colors.Length - 1);
        var amount = position - leftIndex;

        return Interpolate(_colors[leftIndex], _colors[rightIndex], amount);
    }

    private static Color Interpolate(Color from, Color to, double amount)
    {
        return new Color(
            (byte)Math.Round(from.R + (to.R - from.R) * amount),
            (byte)Math.Round(from.G + (to.G - from.G) * amount),
            (byte)Math.Round(from.B + (to.B - from.B) * amount));
    }
}
