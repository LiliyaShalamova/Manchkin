﻿using Manchkin.Core.Cards.Doors;

namespace Manchkin.Extensions.CurseExtensions;

public static class CurseExtension
{
    public static void Print(this ICurse curse)
    {
        Console.WriteLine($"Карта Проклятие. {curse.Title}");
    }
}