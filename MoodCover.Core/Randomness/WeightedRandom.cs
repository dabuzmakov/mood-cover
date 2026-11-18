namespace MoodCover.Core;

internal class WeightedRandom<T>
{
    private readonly Random _random;
    private readonly IReadOnlyList<(T Value, double Weight)> _weightedList;
    private readonly double _totalWeight;

    internal WeightedRandom(Random random, IReadOnlyList<(T Value, double Weight)> weightedList)
    {
        if (weightedList.Count == 0 || weightedList.Any(pair => pair.Weight <= 0))
            throw new ArgumentException();

        _random = random;
        _weightedList = weightedList;
        _totalWeight = _weightedList.Sum(pair => pair.Weight);
    }

    internal T Next()
    {
        var value = _random.NextDouble() * _totalWeight;
        var cumulativeWeight = 0d;

        foreach (var rule in _weightedList)
        {
            cumulativeWeight += rule.Weight;

            if (value < cumulativeWeight)
                return rule.Value;
        }

        return _weightedList[^1].Value;
    }
}
