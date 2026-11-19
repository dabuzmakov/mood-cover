namespace MoodCover.Core.Fractal_Flame.Palettes;

public class WarmPalette : IPalette
{
    private static readonly (byte R, byte G, byte B) Red = (190, 35, 20);
    private static readonly (byte R, byte G, byte B) Orange = (255, 120, 25);
    private static readonly (byte R, byte G, byte B) Yellow = (255, 225, 130);

    public string Name => "warm";

    public (byte R, byte G, byte B) Get(double coordinate)
    {
        if (coordinate is not (>= 0.0 and <= 1.0))
            throw new ArgumentOutOfRangeException(nameof(coordinate));

        if (coordinate <= 0.5)
            return Interpolate(Red, Orange, coordinate * 2.0);

        return Interpolate(Orange, Yellow, (coordinate - 0.5) * 2.0);
    }

    private static (byte R, byte G, byte B) Interpolate(
        (byte R, byte G, byte B) from,
        (byte R, byte G, byte B) to,
        double amount)
    {
        return (
            (byte)Math.Round(from.R + (to.R - from.R) * amount),
            (byte)Math.Round(from.G + (to.G - from.G) * amount),
            (byte)Math.Round(from.B + (to.B - from.B) * amount));
    }
}
