using MoodCover.Core.Fractal_Flame;

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
}
