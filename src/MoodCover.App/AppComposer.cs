using MoodCover.Core.Fractal_Flame;
using MoodCover.Core.Fractal_Flame.Palettes;
using MoodCover.Core.Fractal_Flame.Variations;
using MoodCover.Core.Registry;
using MoodCover.Core.Render;
using MoodCover.Core.Variations;

namespace MoodCover.App;

public class AppComposer
{
    public FractalFlameRenderer Renderer { get; }
    public PngImageSaver Saver { get; }
    public NamedRegistry<IVariation> Variations { get; }
    public NamedRegistry<IPalette> Palettes { get; }

    public AppComposer(
        FractalFlameRenderer? renderer = null,
        PngImageSaver? saver = null,
        NamedRegistry<IVariation>? variations = null,
        NamedRegistry<IPalette>? palettes = null)
    {
        Renderer = renderer ?? new FractalFlameRenderer();
        Saver = saver ?? new PngImageSaver();

        Variations = variations ?? new NamedRegistry<IVariation>(
            [
                new LinearVariation(),
                new SinusoidalVariation(),
                new SphericalVariation(),
                new SwirlVariation(),
                new HorseshoeVariation(),
                new PolarVariation(),
                new HeartVariation(),
                new DiskVariation()
            ],
            v => v.Name);

        Palettes = palettes ?? new NamedRegistry<IPalette>(
            [
                new GradientPalette("warm",
                    new Color(190, 35, 20),
                    new Color(255, 120, 25),
                    new Color(255, 225, 130)),

                new GradientPalette("cold",
                    new Color(20, 35, 110),
                    new Color(100, 225, 255)),

                new GradientPalette("neon",
                    new Color(255, 0, 160),
                    new Color(90, 30, 255),
                    new Color(0, 245, 255),
                    new Color(170, 255, 0)),

                new GradientPalette("pastel",
                    new Color(255, 182, 193),
                    new Color(210, 190, 255),
                    new Color(170, 230, 210)),

                new GradientPalette("mono",
                    new Color(60, 60, 60),
                    new Color(255, 255, 255)),

                new GradientPalette("rainbow",
                    new Color(255, 0, 0),
                    new Color(255, 127, 0),
                    new Color(255, 255, 0),
                    new Color(0, 200, 0),
                    new Color(0, 170, 255),
                    new Color(45, 45, 255),
                    new Color(148, 0, 211))
            ],
            p => p.Name);
    }
}
