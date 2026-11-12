namespace MoodCover.Tests.Mandatory.Mr2;

/// <summary>
/// Обязательные юнит-тесты MR2: чтение JSON-конфига, дефолты и приоритет
/// CLI над конфигом. Вызывают логику разбора конфига напрямую.
///
/// Валидация значений через настоящий CLI (ненулевой код возврата) лежит в
/// <c>MoodCover.IntegrationTests.Mandatory.Mr2.CliValidationTest</c>.
/// </summary>
public class ConfigTest
{
    [Fact(DisplayName = "Параметры читаются из JSON-конфига",
          Skip = "MR2: реализуй тест и удали эту строку")]
    public void ParametersAreReadFromJson()
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Невалидный JSON отклоняется",
          Skip = "MR2: реализуй тест и удали эту строку")]
    public void InvalidJsonIsRejected()
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Дефолты заполняют пропущенные поля конфига",
          Skip = "MR2: реализуй тест и удали эту строку")]
    public void DefaultsFillTheGaps()
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "CLI-параметры имеют приоритет над JSON-конфигом",
          Skip = "MR2: реализуй тест и удали эту строку")]
    public void CliOverridesJson()
    {
        // JSON threads=2 + CLI --threads 4 => threads = 4
        Assert.Fail("Тест не реализован");
    }
}