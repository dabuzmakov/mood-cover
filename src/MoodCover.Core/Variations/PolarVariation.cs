using MoodCover.Core.Fractal_Flame.Variations;

namespace MoodCover.Core.Variations;

public class PolarVariation : IVariation
{
    public string Name => "polar";

    public (double X, double Y) Apply(double x, double y)
    {
        var radius = Math.Sqrt(x * x + y * y);
        var angle = Math.Atan2(x, y);

        return (angle / Math.PI, radius - 1.0);
    }
}
