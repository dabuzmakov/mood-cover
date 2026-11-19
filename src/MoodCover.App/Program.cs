using MoodCover.Core.Fractal_Flame;
using MoodCover.Core.Fractal_Flame.Palettes;
using MoodCover.Core.Fractal_Flame.Variations;
using MoodCover.Core.Registry;

public class Program
{
    public static void Main(string[] args)
    {
        var paletteRegistry = new NamedRegistry<IPalette>(
            [new WarmPalette()],
            p => p.Name);

        var variationsRegistry = new NamedRegistry<IVariation>(
            [new LinearVariation()],
            v => v.Name);

        var renderer = new FractalFlame();
    }
}