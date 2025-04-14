namespace Manchkin.Core.Generators;

internal class RandomEnumValueGenerator : IRandomEnumValueGenerator
{
    private readonly IRandom _random;
    
    public RandomEnumValueGenerator(IRandom random)
    {
        _random = random;
    }
    
    public T Generate<T>() where T : struct, Enum
    {
        var enumValues = Enum.GetValues<T>();
        var value = (T)enumValues.GetValue(_random.Next(enumValues.Length))!;
        return value;
    }

    public T GenerateExcept<T>(params T[] except) where T : struct, Enum
    {
        var enumValues = Enum.GetValues<T>().Where(value => !except.Contains(value)).ToArray();
        var value = (T)enumValues.GetValue(_random.Next(enumValues.Length))!;
        return value;
    }
}