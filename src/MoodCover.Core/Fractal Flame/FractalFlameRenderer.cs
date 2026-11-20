using MoodCover.Core.Extensions;
using MoodCover.Core.Fractal_Flame.Variations;
using MoodCover.Core.Options;
using MoodCover.Core.Randomness;

namespace MoodCover.Core.Fractal_Flame;

public class FractalFlameRenderer
{
    public async Task<PixelAccumulator[,]> AccumulateHitsAsync(FractalFlameOptions options)
    {
        var random = new Random(options.Seed);
        var affineColorCoordinates = GetRandomColors(random, options.AffineParams.Count);

        var chainCount = Math.Min(options.Threads, options.Iterations);

        if (chainCount == 1)
            return AccumulateChainHits(options, affineColorCoordinates);

        var iterationsPerChain = options.Iterations / chainCount;
        var remainder = options.Iterations % chainCount;
        var tasks = new Task<PixelAccumulator[,]>[chainCount];

        for (var i = 0; i < chainCount; i++)
        {
            var chainOptions = options with
            {
                Iterations = iterationsPerChain + (i < remainder ? 1 : 0),
                Seed = random.Next(),
                Threads = 1
            };

            tasks[i] = Task.Run(
                () => AccumulateChainHits(chainOptions, affineColorCoordinates));
        }

        var buffers = await Task.WhenAll(tasks);
        return buffers.Merge();
    }

    private PixelAccumulator[,] AccumulateChainHits(
        FractalFlameOptions options, IReadOnlyList<double> colorCoordinates)
    {
        var (width, height) = (options.Width, options.Height);
        var buffer = new PixelAccumulator[height, width];

        var random = new Random(options.Seed);
        var variationRandom = new WeightedRandom<IVariation>(random, options.VariationSelectonRules);

        var (x, y) = GetRandomPoint(random, width, height);
        var colorCoordinate = random.NextDouble();

        for (var iteration = 0; iteration < options.Iterations; iteration++)
        {
            var affineIndex = random.Next(options.AffineParams.Count);

            var affine = options.AffineParams[affineIndex];
            (x, y) = ApplyAffine(x, y, affine);

            var variation = variationRandom.Next();
            (x, y) = variation.Apply(x, y);
            
            colorCoordinate = (colorCoordinate + colorCoordinates[affineIndex]) / 2.0;

            if (MapToPixel(x, y, width, height) is { } pixel)
            {
                var color = options.Palette.Get(colorCoordinate);
                buffer[pixel.Row, pixel.Col].AddHit(color);
            }
        }

        return buffer;
    }

    private static (double X, double Y) ApplyAffine(
        double x, double y, AffineParameters affine)
    {
        var newX = affine.A * x + affine.B * y + affine.C;
        var newY = affine.D * x + affine.E * y + affine.F;

        return (newX, newY);
    }

    private static (double X, double Y) GetRandomPoint(
        Random random, int width, int height)
    {
        var aspect = (double)width / height;
        var x = (2.0 * random.NextDouble() - 1.0) * aspect;
        var y = 2.0 * random.NextDouble() - 1.0;

        return (x, y);
    }

    private static IReadOnlyList<double> GetRandomColors(
        Random random, int colorsCount)
    {
        return Enumerable.Range(0, colorsCount)
            .Select(_ => random.NextDouble())
            .ToArray();
    }

    private static (int Row, int Col)? MapToPixel(
        double x, double y, int width, int height)
    {
        var scale = height / 2.0;

        var pixelX = width / 2.0 + x * scale;
        var pixelY = height / 2.0 - y * scale;

        if (pixelX >= 0 && pixelX < width &&
            pixelY >= 0 && pixelY < height)
        {
            return ((int)pixelY, (int)pixelX);
        }

        return null;
    }
}
