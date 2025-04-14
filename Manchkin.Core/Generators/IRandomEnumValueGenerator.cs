namespace Manchkin.Core.Generators;

public interface IRandomEnumValueGenerator
{
    T Generate<T>() where T : struct, Enum;
    T GenerateExcept<T>(params T[] except) where T : struct, Enum;
}