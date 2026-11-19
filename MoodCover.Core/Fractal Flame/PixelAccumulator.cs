using MoodCover.Core.Fractal_Flame.Palettes;

namespace MoodCover.Core.Fractal_Flame;

public struct PixelAccumulator
{
    public long SumR { get; private set; }
    public long SumG { get; private set; }
    public long SumB { get; private set; }
    public int Hits { get; private set; }

    public void AddHit(Color color)
    {
        SumR += color.R;
        SumG += color.G;
        SumB += color.B;
        Hits++;
    }

    public void MergeFrom(PixelAccumulator other)
    {
        Hits += other.Hits;
        SumR += other.SumR;
        SumG += other.SumG;
        SumB += other.SumB;
    }
}
