using System.Diagnostics;
using System.Text;

namespace MoodCover.IntegrationTests.Support;

/// <summary>
/// Запускает собранный исполняемый файл приложения отдельным процессом
/// и возвращает его вывод и код возврата.
///
/// <para>Отдельный процесс нужен, потому что иначе нельзя проверить код возврата
/// и поведение настоящего CLI: код, вызывающий <c>Environment.Exit</c>, завершил бы
/// весь процесс тестов.</para>
///
/// <para>Класс дан готовым, писать его не нужно. Пример:</para>
///
/// <code>
/// var result = CliRunner.Run("--width", "0", "--output", "result.png");
///
/// Assert.NotEqual(0, result.ExitCode);
/// Assert.Contains("width", result.Stderr);
/// </code>
/// </summary>
public static class CliRunner
{
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(30);

    /// <summary>Результат запуска приложения.</summary>
    public sealed record Result(int ExitCode, string Stdout, string Stderr)
    {
        public override string ToString() =>
            $"exitCode={ExitCode}\nstdout:\n{Stdout}\nstderr:\n{Stderr}";
    }

    /// <summary>Запуск с аргументами, без ввода с клавиатуры.</summary>
    public static Result Run(params string[] args) => Run(null, null, args);

    /// <summary>Запуск с подачей строк на стандартный ввод.</summary>
    public static Result RunWithInput(string stdin, params string[] args) => Run(null, stdin, args);

    /// <summary>
    /// Полная форма запуска.
    /// </summary>
    /// <param name="workingDirectory">
    /// Рабочая директория процесса; <c>null</c> — текущая. Пригодится с xUnit
    /// <c>@TempDir</c>, когда программа пишет файлы (PNG, отчёты).
    /// </param>
    /// <param name="stdin">Данные для стандартного ввода или <c>null</c>.</param>
    /// <param name="args">Аргументы командной строки.</param>
    public static Result Run(string? workingDirectory, string? stdin, params string[] args)
    {
        var startInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            UseShellExecute = false,
            WorkingDirectory = workingDirectory ?? Environment.CurrentDirectory,
        };
        startInfo.ArgumentList.Add(AppDllPath);
        foreach (var arg in args)
        {
            startInfo.ArgumentList.Add(arg);
        }

        using var process = new Process { StartInfo = startInfo };
        var stdout = new StringBuilder();
        var stderr = new StringBuilder();
        process.OutputDataReceived += (_, e) =>
        {
            if (e.Data is not null)
            {
                stdout.AppendLine(e.Data);
            }
        };
        process.ErrorDataReceived += (_, e) =>
        {
            if (e.Data is not null)
            {
                stderr.AppendLine(e.Data);
            }
        };

        if (!process.Start())
        {
            throw new InvalidOperationException($"Не удалось запустить программу: dotnet {AppDllPath}");
        }

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        if (stdin is not null)
        {
            process.StandardInput.Write(stdin);
        }
        process.StandardInput.Close();

        if (!process.WaitForExit((int)Timeout.TotalMilliseconds))
        {
            process.Kill(entireProcessTree: true);
            throw new TimeoutException(
                $"Программа не завершилась за {Timeout.TotalSeconds} с — похоже, ждёт ввода, которого нет.\n" +
                $"stdout:\n{stdout}");
        }

        // Дождаться, пока асинхронные читатели допишут stdout/stderr.
        process.WaitForExit();
        return new Result(process.ExitCode, stdout.ToString(), stderr.ToString());
    }

    /// <summary>
    /// Путь к собранному исполняемому файлу приложения. Он лежит рядом с тестами,
    /// потому что <c>MoodCover.App</c> подключён как project reference.
    /// </summary>
    public static string AppDllPath => Path.Combine(AppContext.BaseDirectory, "MoodCover.App.dll");
}