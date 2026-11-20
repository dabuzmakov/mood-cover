using MoodCover.Core.Fractal_Flame.Variations;

namespace MoodCover.Core.Variations;

public class HeartVariation : IVariation
{
    public string Name => "heart";

    public (double X, double Y) Apply(double x, double y)
    {
        var radius = Math.Sqrt(x * x + y * y);
        var angle = Math.Atan2(x, y) * radius;

        return (radius * Math.Sin(angle), -radius * Math.Cos(angle));
    }
}
