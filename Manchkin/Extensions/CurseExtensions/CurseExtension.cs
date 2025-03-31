using Manchkin.Core;
using Manchkin.Core.Cards.Doors.Curses;

namespace Manchkin.Extensions;

public static class CurseExtension
{
    public static void Print(this Curse curse)
    {
        Console.WriteLine($"Карта Проклятие. {curse.Title}");
    }
}