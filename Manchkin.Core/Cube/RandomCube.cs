namespace Manchkin.Core.Cube;

internal class RandomCube : ICube
{
    public int Throw(int value1, int value2)
    {
        return new Random().Next(value1, value2);
    }
}