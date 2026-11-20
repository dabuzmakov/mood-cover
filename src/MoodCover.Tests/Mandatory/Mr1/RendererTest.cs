using FluentAssertions;
using MoodCover.App;
using MoodCover.Core.Fractal_Flame;
using MoodCover.Core.Options;

namespace MoodCover.Tests.Mandatory.Mr1;

/// <summary>
/// Обязательные юнит-тесты MR1: формулы аффинного преобразования,
/// трансформации и воспроизводимость по seed.
///
/// Вызывают классы рендерера напрямую (в памяти), без запуска приложения.
/// Проверки создания PNG-файла лежат в <c>MoodCover.IntegrationTests.Mandatory.Mr1.CliRenderTest</c>.
/// </summary>
public class RendererTest
{
    private static readonly AppComposer _app = new AppComposer();

    private static readonly FractalFlameOptions _testOptions = new(
        VariationSelectonRules:
        [
            (_app.Variations.Get("linear"), 1.0),
            (_app.Variations.Get("sinusoidal"), 1.0)
        ],
        AffineParams:
        [
            new(0.5, 0, -0.6, 0, 0.5, -0.25),
            new(0.5, 0,  0.6, 0, 0.5,  0.25)
        ],
        Palette: _app.Palettes.Get("warm"),
        Iterations: 1025,
        Threads: 1,
        Height: 40,
        Width: 64,
        Seed: 1);

    [Theory(DisplayName = "Аффинное преобразование считается по формуле на известных числах")]
    [InlineData(2.0, -3.0, 5.0, -4.0, 6.0, -7.0, 3.0, -2.0, 17.0, -31.0)]
    [InlineData(1.0, 0.0, 0.0, 0.0, 1.0, 0.0, 3.0, -2.0, 3.0, -2.0)]
    [InlineData(1.0, 0.0, 5.0, 0.0, 1.0, -7.0, 3.0, -2.0, 8.0, -9.0)]
    [InlineData(0.0, -1.0, 0.0, 1.0, 0.0, 0.0, 3.0, -2.0, 2.0, 3.0)]
    public void AffineTransformFollowsFormula(
        double a, double b, double c, double d, double e, double f,
        double x, double y, double expectedX, double expectedY)
    {
        var affine = new AffineParameters(a, b, c, d, e, f);

        var (actualX, actualY) = affine.Apply(x, y);

        actualX.Should().Be(expectedX);
        actualY.Should().Be(expectedY);
    }

    [Theory(DisplayName = "Каждая трансформация переводит фиксированную точку в посчитанное вручную значение")]
    [InlineData("linear", 0.6, 0.8, 0.6, 0.8)]
    [InlineData("sinusoidal", 0.6, 0.8, 0.5646424733950354, 0.7173560908995228)]
    [InlineData("spherical", 0.6, 0.8, 0.6, 0.8)]
    [InlineData("spherical", 3.0, 4.0, 0.12, 0.16)]
    [InlineData("swirl", 0.6, 0.8, 0.0726407461902260, 0.9973581713672011)]
    [InlineData("horseshoe", 0.6, 0.8, -0.28, 0.96)]
    [InlineData("polar", 0.6, 0.8, 0.2048327646991335, 0.0)]
    [InlineData("heart", 0.6, 0.8, 0.6, -0.8)]
    [InlineData("disk", 0.6, 0.8, 0.0, -0.2048327646991335)]
    public void EveryVariationMatchesExpectedPoint(
        string variationName, double x, double y,
        double expectedX, double expectedY)
    {
        var variation = _app.Variations.Get(variationName);
        var result = variation.Apply(x, y);

        result.X.Should().BeApproximately(expectedX, 1e-12);
        result.Y.Should().BeApproximately(expectedY, 1e-12);
    }

    [Fact(DisplayName = "Одинаковый конфиг и seed дают одинаковый результат (в памяти)")]
    public async Task SameSeedProducesSameResult()
    {
        var renderer = new FractalFlameRenderer();

        var firstResult = await renderer.AccumulateHitsAsync(_testOptions);
        var secondResult = await renderer.AccumulateHitsAsync(_testOptions);

        firstResult.Cast<PixelAccumulator>()
            .SequenceEqual(secondResult.Cast<PixelAccumulator>())
            .Should().BeTrue();
    }

    [Fact(DisplayName = "Разный seed даёт разный результат")]
    public async Task DifferentSeedProducesDifferentResult()
    {
        var renderer = new FractalFlameRenderer();

        var firstResult = await renderer.AccumulateHitsAsync(_testOptions with { Seed = 1 });
        var secondResult = await renderer.AccumulateHitsAsync(_testOptions with { Seed = 2 });

        firstResult.Cast<PixelAccumulator>()
            .SequenceEqual(secondResult.Cast<PixelAccumulator>())
            .Should().BeFalse();
    }
}