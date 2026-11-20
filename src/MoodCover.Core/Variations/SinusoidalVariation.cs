using MoodCover.Core.Fractal_Flame.Variations;

namespace MoodCover.Core.Variations;

public class SinusoidalVariation : IVariation
{
    public string Name => "sinusoidal";

    public (double X, double Y) Apply(double x, double y)
        => (Math.Sin(x), Math.Sin(y));
}
