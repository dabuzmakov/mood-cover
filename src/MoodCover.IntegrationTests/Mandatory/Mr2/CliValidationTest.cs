using MoodCover.IntegrationTests.Support;

namespace MoodCover.IntegrationTests.Mandatory.Mr2;

/// <summary>
/// Интеграционные тесты MR2: запускают собранный исполняемый файл и проверяют
/// валидацию аргументов — невалидный ввод даёт ненулевой код возврата и понятное
/// сообщение об ошибке.
///
/// Разбор JSON-конфига, дефолты и приоритет проверяются юнит-тестами в
/// <c>MoodCover.Tests.Mandatory.Mr2.ConfigTest</c>.
/// </summary>
public class CliValidationTest
{
    [Theory(DisplayName = "width/height/iterations/threads <= 0 -> ненулевой код возврата",
            Skip = "MR2: реализуй тест и удали эту строку")]
    [InlineData("--width", "0")]
    [InlineData("--height", "-5")]
    [InlineData("--iterations", "0")]
    [InlineData("--threads", "-1")]
    public void NonPositiveNumbersAreRejected(string option, string value)
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Пустой список трансформаций -> ненулевой код возврата",
          Skip = "MR2: реализуй тест и удали эту строку")]
    public void EmptyFunctionListIsRejected()
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Неизвестная трансформация -> ненулевой код возврата и сообщение",
          Skip = "MR2: реализуй тест и удали эту строку")]
    public void UnknownFunctionIsRejected()
    {
        // Например --functions spiral:1.0 -> stderr содержит "spiral".
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Output без расширения .png -> ненулевой код возврата",
          Skip = "MR2: реализуй тест и удали эту строку")]
    public void OutputWithoutPngExtensionIsRejected()
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "CLI --threads имеет приоритет над JSON-конфигом",
          Skip = "MR2: реализуй тест и удали эту строку")]
    public void CliOverridesJson()
    {
        // JSON threads=2 + CLI --threads 4 => приложение должно использовать 4 потока.
        Assert.Fail("Тест не реализован");
    }
}