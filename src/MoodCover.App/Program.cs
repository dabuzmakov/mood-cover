using MoodCover.App;
using MoodCover.Core.Options;

public class Program
{
    public static async Task Main(string[] args)
    {
        var app = new AppComposer();

        var options = new FractalFlameOptions(
            VariationSelectonRules:
            [
                (app.Variations.Get("disk"), 4.0),
                (app.Variations.Get("swirl"), 2.0),
                (app.Variations.Get("linear"), 1.0)
            ],
            AffineParams:
            [
                new(0.60, -0.25, -1.00,  0.25, 0.60, -0.33),
                new(0.60,  0.25,  1.00, -0.25, 0.60,  0.33),
                new(0.56,  0.00,  0.00,  0.00, 0.56,  0.58)
            ],
            Palette: app.Palettes.Get("rainbow"),
            Iterations: 100_000_000,
            Threads: 8,
            Height: 1080,
            Width: 1920,
            Seed: 1);

        var buffer = await app.Renderer.AccumulateHitsAsync(options);
        await app.Saver.SaveAsync(buffer, "image.png");
    }
}