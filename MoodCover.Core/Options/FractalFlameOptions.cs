using MoodCover.Core.Fractal_Flame.Palettes;
using MoodCover.Core.Fractal_Flame.Variations;

namespace MoodCover.Core.Options;

public record FractalFlameOptions(
    IReadOnlyList<(IVariation Variation, double Weight)> VariationSelectonRules,
    IReadOnlyList<AffineParameters> AffineParams,
    IPalette Palette,
    int Iterations,
    int Threads,
    int Height,
    int Width,
    int Seed);
