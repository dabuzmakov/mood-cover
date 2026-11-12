using MoodCover.IntegrationTests.Support;

namespace MoodCover.IntegrationTests.Mandatory.Mr1;

/// <summary>
/// Интеграционные тесты MR1: запускают собранный исполняемый файл отдельным
/// процессом и проверяют создание PNG-файла по конфигу.
///
/// Формулы аффинного преобразования и трансформаций проверяются юнит-тестами
/// в <c>MoodCover.Tests.Mandatory.Mr1.RendererTest</c>.
/// </summary>
public class CliRenderTest
{
    [Fact(DisplayName = "PNG создан, не пуст и имеет размер из конфига",
          Skip = "MR1: реализуй тест и удали эту строку")]
    public void PngIsCreatedWithConfiguredSize()
    {
        // Запусти приложение с рабочей директорией @TempDir и проверь result.png.
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Одинаковые входные параметры дают одинаковый PNG-файл",
          Skip = "MR1: реализуй тест и удали эту строку")]
    public void SameInputsProduceSamePng()
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Разный seed даёт разный PNG-файл",
          Skip = "MR1: реализуй тест и удали эту строку")]
    public void DifferentSeedProducesDifferentPng()
    {
        Assert.Fail("Тест не реализован");
    }
}