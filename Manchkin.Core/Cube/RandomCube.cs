namespace Manchkin.Core.Cube;

internal class RandomCube : ICube
{
    public CubeFace Throw()
    {
        return (CubeFace)new Random().Next(1, 7);
    }
}