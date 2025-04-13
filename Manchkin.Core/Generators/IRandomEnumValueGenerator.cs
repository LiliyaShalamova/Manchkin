namespace Manchkin.Core.Generators;

public interface IRandomEnumValueGenerator
{
    T GetRandomValueByEnumType<T>() where T : struct, Enum;
    T GetRandomValueExcept<T>(List<T> except) where T : struct, Enum;
}