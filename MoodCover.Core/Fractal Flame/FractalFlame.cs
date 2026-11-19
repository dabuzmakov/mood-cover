using MoodCover.Core.Extensions;
using MoodCover.Core.Fractal_Flame.Variations;
using MoodCover.Core.Options;
using MoodCover.Core.Randomness;
using System.Collections.Immutable;

namespace MoodCover.Core.Fractal_Flame;

public class FractalFlame
{
    private readonly IVariationFactory _variationFactory;

    public FractalFlame(IVariationFactory variationFactory)
    {
        _variationFactory = variationFactory;
    }

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

            tasks[i] = Task.Run(() => AccumulateChainHits(chainOptions, affineColorCoordinates));
        }

        var buffers = await Task.WhenAll(tasks);
        return buffers.Merge();
    }

    private PixelAccumulator[,] AccumulateChainHits(
        FractalFlameOptions options, IReadOnlyList<double> affineColorCoordinates)
    {
        var buffer = new PixelAccumulator[options.Height, options.Width];
        var variationWeightedRules = options.Variations
            .Select(v => (_variationFactory.Get(v.Name), v.Weight))
            .ToList();

        var random = new Random(options.Seed);
        var variationRandom = new WeightedRandom<IVariation>(random, variationWeightedRules);
        var (x, y) = GetRandomPoint(random, options.Width, options.Height);

        for (var iteration = 0; iteration < options.Iterations; iteration++)
        {
            var affineIndex = random.Next(options.AffineParams.Count);
            var affine = options.AffineParams[affineIndex];

            (x, y) = ApplyAffine(x, y, affine);

            var variation = variationRandom.Next();
            (x, y) = variation.Apply(x, y);
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
}
