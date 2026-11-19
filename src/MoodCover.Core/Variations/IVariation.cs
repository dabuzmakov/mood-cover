namespace MoodCover.Core.Fractal_Flame.Variations;

public interface IVariation
{
    public (double X, double Y) Apply(double X, double Y);
    public string Name { get; }
}
