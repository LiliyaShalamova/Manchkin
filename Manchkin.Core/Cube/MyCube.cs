using Manchkin.Core.Cube;

namespace Manchkin.Core;

public class MyCube : ICube
{
    public int Throw(int value1, int value2)
    {
        return new Random().Next(value1, value2);
    }
}