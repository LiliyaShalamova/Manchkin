namespace Manchkin.Core.Generators;

public interface IRandom
{
    int Next(int min, int max);
    
    int Next(int max);
}