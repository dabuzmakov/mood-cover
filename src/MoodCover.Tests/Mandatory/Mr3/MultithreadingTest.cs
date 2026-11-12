namespace MoodCover.Tests.Mandatory.Mr3;

/// <summary>
/// Обязательные юнит-тесты MR3: многопоточный рендер «в памяти» — без гонок
/// и с воспроизводимым результатом для фиксированного числа потоков.
///
/// Проверка benchmark-отчёта через настоящий CLI лежит в
/// <c>MoodCover.IntegrationTests.Mandatory.Mr3.CliBenchmarkTest</c>.
/// </summary>
public class MultithreadingTest
{
    [Fact(DisplayName = "Рендер на 2 и 4 потоках даёт ненулевой буфер пикселей",
          Skip = "MR3: реализуй тест и удали эту строку")]
    public void MultithreadedRenderProducesNonEmptyBuffer()
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "Одинаковый конфиг + seed + число потоков дают одинаковый результат",
          Skip = "MR3: реализуй тест и удали эту строку")]
    public void ResultIsReproducibleForFixedThreadCount()
    {
        Assert.Fail("Тест не реализован");
    }

    [Fact(DisplayName = "При многопоточном рендере нет исключений конкурентного доступа",
          Skip = "MR3: реализуй тест и удали эту строку")]
    public void NoConcurrentAccessExceptions()
    {
        Assert.Fail("Тест не реализован");
    }
}