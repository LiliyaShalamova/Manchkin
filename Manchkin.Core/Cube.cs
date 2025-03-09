namespace Manchkin.Core;

public static class Cube
{
    private static readonly Random Random = new Random();
    public static int Throw()
    {
        return Random.Next(1, 6);
    }
}