using Manchkin.Core;

namespace Manchkin.Extensions;

public static class CurseExtension
{
    public static void Print(this Curse curse)
    {
        Console.WriteLine($"Карта Проклятие. {curse.Title}");
    }
}