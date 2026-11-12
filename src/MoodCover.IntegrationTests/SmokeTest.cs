using MoodCover.IntegrationTests.Support;

namespace MoodCover.IntegrationTests;

/// <summary>
/// Базовые проверки, что собранный исполняемый файл запускается.
/// Эти тесты активны с самого начала — они держат CI зелёным даже до
/// реализации рендерера.
/// </summary>
public class SmokeTest
{
    [Fact(DisplayName = "Приложение запускается отдельным процессом и завершается с кодом 0")]
    public void AppStartsAndExitsWithZero()
    {
        var result = CliRunner.Run("--help");

        Assert.Equal(0, result.ExitCode);
        Assert.NotEmpty(result.Stdout);
    }

    [Fact(DisplayName = "Исполняемый файл приложения найден рядом с тестами")]
    public void AppExecutableExists()
    {
        Assert.True(File.Exists(CliRunner.AppDllPath), $"Не найден {CliRunner.AppDllPath}");
    }
}