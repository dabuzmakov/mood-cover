namespace MoodCover.Core.Fractal_Flame.Palettes;

public interface IPalette
{
    Color Get(double coordinate);
    string Name { get; }
}
