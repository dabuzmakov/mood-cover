using MoodCover.Core.Fractal_Flame.Variations;

namespace MoodCover.Core.Variations;

public class SphericalVariation : IVariation
{
    public string Name => "spherical";

    public (double X, double Y) Apply(double x, double y)
    {
        var radiusSquared = x * x + y * y;

        if (radiusSquared == 0.0)
            return (0.0, 0.0);

        return (x / radiusSquared, y / radiusSquared);
    }
}
