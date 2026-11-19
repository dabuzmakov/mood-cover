using MoodCover.Core.Fractal_Flame;
using MoodCover.Core.Fractal_Flame.Variations;

public class Program
{
    public static void Main(string[] args)
    {
        var variationFactory = new VariationFactory(
            new LinearVariation()
            );

        var renderer = new FractalFlame(variationFactory);
    }
}