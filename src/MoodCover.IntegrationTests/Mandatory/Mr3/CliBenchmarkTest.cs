using MoodCover.IntegrationTests.Support;

namespace MoodCover.IntegrationTests.Mandatory.Mr3;

/// <summary>
/// Интеграционные тесты MR3: запускают собранный исполняемый файл в
/// benchmark-режиме и проверяют отчёт.
///
/// Многопоточный рендер «в памяти» проверяется юнит-тестами в
/// <c>MoodCover.Tests.Mandatory.Mr3.MultithreadingTest</c>.
/// </summary>
public class CliBenchmarkTest
{
    [Fact(DisplayName = "Benchmark-отчёт создан и содержит строки для 1/2/4/8 потоков",
          Skip = "MR3: реализуй тест и удали эту строку")]
    public void BenchmarkReportHasAllThreadCounts()
    {
        // mood-cover benchmark --config ... --threads 1,2,4,8 --output benchmark.md
        Assert.Fail("Тест не реализован");
    }
}