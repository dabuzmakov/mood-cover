using MoodCover.Core.Extensions;
using MoodCover.Core.Options;

namespace MoodCover.Core.Fractal_Flame;

public class FractalFlame
{
    public async Task<PixelAccumulator[,]> AccumulateHits(FractalFlameOptions options)
    {
        var chainCount = Math.Min(options.Threads, options.Iterations);

        if (chainCount == 1)
            return AccumulateChainHits(options);

        var iterationsPerChain = options.Iterations / chainCount;
        var remainder = options.Iterations % chainCount;
        var seedGenerator = new Random(options.Seed);
        var tasks = new Task<PixelAccumulator[,]>[chainCount];

        for (var i = 0; i < chainCount; i++)
        {
            var chainOptions = options with
            {
                Iterations = iterationsPerChain + (i < remainder ? 1 : 0),
                Seed = seedGenerator.Next(),
                Threads = 1
            };

            tasks[i] = Task.Run(() => AccumulateChainHits(chainOptions));
        }

        var buffers = await Task.WhenAll(tasks);
        return buffers.Merge();
    }

    private static PixelAccumulator[,] AccumulateChainHits(FractalFlameOptions options)
    {
        var buffer = new PixelAccumulator[options.Height, options.Width];

        // заполняем буфер

        return buffer;
    }
}
