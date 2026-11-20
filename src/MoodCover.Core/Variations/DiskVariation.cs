using MoodCover.Core.Fractal_Flame.Variations;

namespace MoodCover.Core.Variations;

public class DiskVariation : IVariation
{
    public string Name => "disk";

    public (double X, double Y) Apply(double x, double y)
    {
        var scaledRadius = Math.PI * Math.Sqrt(x * x + y * y);
        var scaledAngle = Math.Atan2(x, y) / Math.PI;

        return (
            scaledAngle * Math.Sin(scaledRadius),
            scaledAngle * Math.Cos(scaledRadius));
    }
}
