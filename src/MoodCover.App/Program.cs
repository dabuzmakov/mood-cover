using MoodCover.Core.Fractal_Flame;
using MoodCover.Core.Fractal_Flame.Palettes;
using MoodCover.Core.Fractal_Flame.Variations;
using MoodCover.Core.Registry;

public class Program
{
    public static void Main(string[] args)
    {
        var paletteRegistry = new NamedRegistry<IPalette>(
            [
                new GradientPalette("warm",
                    new Color(190, 35, 20),
                    new Color(255, 120, 25),
                    new Color(255, 225, 130)),
                new GradientPalette("cold",
                    new Color(20, 35, 110),
                    new Color(100, 225, 255))
            ],
            p => p.Name);

        var variationsRegistry = new NamedRegistry<IVariation>(
            [new LinearVariation()],
            v => v.Name);

        var renderer = new FractalFlame();
    }
}