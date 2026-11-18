namespace MoodCover.Core.Options;

public record FractalFlameOptions(
    IReadOnlyList<VariationOptions> Variations,
    IReadOnlyList<AffineParameters> AffineParams,
    string Palette,
    int Iterations,
    int Threads,
    int Height,
    int Width,
    int Seed);
