using MoodCover.Core.Fractal_Flame.Palettes;
using SixLabors.ImageSharp.PixelFormats;

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

    public Rgb24 ToRgb24(double maxLogDensity, double gamma)
    {
        var brightness = Math.Log(1.0 + Hits) / maxLogDensity;
        var correctedBrightness = Math.Pow(brightness, 1 / gamma);
        var colorScale = correctedBrightness / Hits;

        return new Rgb24(
            (byte)Math.Round(SumR * colorScale),
            (byte)Math.Round(SumG * colorScale),
            (byte)Math.Round(SumB * colorScale));
    }
}
