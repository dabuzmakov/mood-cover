using MoodCover.Core.Extensions;
using MoodCover.Core.Fractal_Flame;
using SixLabors.ImageSharp;

namespace MoodCover.Core.Render;

public class PngImageSaver
{
    public async Task SaveAsync(PixelAccumulator[,] buffer, string path, double gamma = 1.0)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

        var fullPath = Path.GetFullPath(path);

        if (!string.Equals(Path.GetExtension(fullPath), ".png", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException(
                "Путь к выходному файлу должен иметь расширение .png.", nameof(path));
        }

        if (!double.IsFinite(gamma) || gamma <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(gamma));
        }

        using var image = buffer.ToImage(gamma);

        await image.SaveAsPngAsync(fullPath);
    }
}
