namespace MoodCover.Core.Fractal_Flame;

internal struct PixelAccumulator
{
    public long SumR { get; private set; }
    public long SumG { get; private set; }
    public long SumB { get; private set; }
    public int Hits { get; private set; }

    public void AddHit(byte r, byte g, byte b)
    {
        SumR += r;
        SumG += g;
        SumB += b;
        Hits++;
    }
}
