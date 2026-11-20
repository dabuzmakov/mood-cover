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
    [Fact(DisplayName = "Аффинное преобразование считается по формуле на известных числах")]
    public void AffineTransformFollowsFormula()
    {
        // xNew = a * x + b * y + c
        // yNew = d * x + e * y + f
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Каждая трансформация переводит фиксированную точку в посчитанное вручную значение",
          Skip = "MR1: реализуй тест и удали эту строку")]
    public void EveryVariationMatchesExpectedPoint()
    {
        // Ожидаемые значения считай на бумаге, а не «как получилось у программы».
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Одинаковый конфиг и seed дают одинаковый результат (в памяти)",
          Skip = "MR1: реализуй тест и удали эту строку")]
    public void SameSeedProducesSameResult()
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Разный seed даёт разный результат",
          Skip = "MR1: реализуй тест и удали эту строку")]
    public void DifferentSeedProducesDifferentResult()
    {
        Assert.Fail("Тест не реализован");
    }
}