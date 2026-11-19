namespace MoodCover.Core.Fractal_Flame.Palettes;

public interface IPalette
{
    (byte R, byte G, byte B) Get(double coordinate);
    string Name { get; }
}
