using MoodCover.Core.Fractal_Flame.Variations;

namespace MoodCover.Core.Variations;

public class HorseshoeVariation : IVariation
{
    public string Name => "horseshoe";

    public (double X, double Y) Apply(double x, double y)
    {
        var radius = Math.Sqrt(x * x + y * y);

        if (radius == 0.0)
        {
            return (0.0, 0.0);
        }

        return ((x - y) * (x + y) / radius, 2.0 * x * y / radius);
    }
}
