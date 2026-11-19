namespace MoodCover.Core.Fractal_Flame.Variations;

public class VariationFactory : IVariationFactory
{
    private readonly Dictionary<string, IVariation> _registeredVariations;

    public VariationFactory(params IVariation[] variations)
    {
        _registeredVariations = variations.ToDictionary(
            variation => variation.Name,
            StringComparer.OrdinalIgnoreCase);
    }

    public IVariation Get(string name)
    {
        if (_registeredVariations.TryGetValue(name, out var variation))
            return variation;

        throw new ArgumentException($"Неизвестная вариация: {name}", nameof(name));
    }
}
