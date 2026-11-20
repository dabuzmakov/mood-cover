namespace MoodCover.Core.Options;

public readonly record struct AffineParameters(
    double A,
    double B,
    double C,
    double D,
    double E,
    double F)
{
    public (double X, double Y) Apply(double x, double y)
    {
        var newX = A * x + B * y + C;
        var newY = D * x + E * y + F;

        return (newX, newY);
    }
}