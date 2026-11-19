namespace MoodCover.Core.Fractal_Flame.Variations;

public class LinearVariation : IVariation
{
    public string Name => "linear";

    public (double X, double Y) Apply(double X, double Y)
    {
        return (X, Y);
    }
}
