using MoodCover.Core.Fractal_Flame.Variations;

namespace MoodCover.Core.Variations;

public class SwirlVariation : IVariation
{
    public string Name => "swirl";

    public (double X, double Y) Apply(double x, double y)
    {
        var radiusSquared = x * x + y * y;
        var sin = Math.Sin(radiusSquared);
        var cos = Math.Cos(radiusSquared);

        return (x * sin - y * cos, x * cos + y * sin);
    }
}
