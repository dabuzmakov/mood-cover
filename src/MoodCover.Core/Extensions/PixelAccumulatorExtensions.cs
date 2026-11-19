using MoodCover.Core.Fractal_Flame;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace MoodCover.Core.Extensions;

public static class PixelAccumulatorExtensions
{
    public static PixelAccumulator[,] Merge(this PixelAccumulator[][,] buffers)
    {
        var rows = buffers[0].GetLength(0);
        var cols = buffers[0].GetLength(1);
        var result = new PixelAccumulator[rows, cols];

        foreach (var source in buffers)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    result[row, col].MergeFrom(source[row, col]);
                }
            }
        }

        return result;
    }

    public static Image<Rgb24> ToImage(this PixelAccumulator[,] buffer, double gamma)
    {
        var image = new Image<Rgb24>(buffer.GetLength(1), buffer.GetLength(0));
        var maxLogDensity = Math.Log(1.0 + FindMaxHits(buffer));

        for (var row = 0; row < image.Height; row++)
        {
            for (var col = 0; col < image.Width; col++)
            {
                var pixel = buffer[row, col];

                if (pixel.Hits > 0)
                    image[col, row] = pixel.ToRgb24(maxLogDensity, gamma);
            }
        }

        return image;
    }

    public static int FindMaxHits(this PixelAccumulator[,] buffer)
    {
        var maxHits = 0;

        foreach (var pixel in buffer)
            maxHits = Math.Max(maxHits, pixel.Hits);

        return maxHits;
    }
}
