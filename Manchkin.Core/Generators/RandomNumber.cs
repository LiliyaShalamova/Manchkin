namespace Manchkin.Core.Generators;

public class RandomNumber : IRandom
{
    private static readonly Random Random = new();
    public int Next(int min, int max)
    {
        return Random.Next(min, max);
    }

    public int Next(int max)
    {
        return Random.Next(max);
    }
}