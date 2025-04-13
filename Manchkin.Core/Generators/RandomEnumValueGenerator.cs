namespace Manchkin.Core.Generators;

internal class RandomEnumValueGenerator : IRandomEnumValueGenerator
{
    private readonly IRandom _random;
    
    public RandomEnumValueGenerator(IRandom random)
    {
        _random = random;
    }
    
    public T GetRandomValueByEnumType<T>() where T : struct, Enum
    {
        var enumValues = Enum.GetValues<T>();
        var value = (T)enumValues.GetValue(_random.Next(enumValues.Length))!; // TODO сделать отдельный класс, который по типу енама возвращает рандомное значение DONE
        return value;
    }

    public T GetRandomValueExcept<T>(List<T> except) where T : struct, Enum
    {
        var enumValues = Enum.GetValues<T>().Where(value => !except.Contains(value)).ToArray();
        var value = (T)enumValues.GetValue(_random.Next(enumValues.Length))!;
        return value;
    }
}