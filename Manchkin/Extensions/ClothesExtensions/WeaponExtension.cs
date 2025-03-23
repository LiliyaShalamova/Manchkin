using Manchkin.Core;

namespace Manchkin.Extensions;

public static class WeaponExtension
{
    public static void Print(this Weapon weapon)
    {
        var big = weapon.IsBig ? " Большая" : string.Empty;
        var wash = weapon.WashBonus != 0 ? $" Бонус на смывку {weapon.WashBonus}" : string.Empty;
        Console.WriteLine($"{weapon.Title} Бонус {weapon.Bonus} Количество рук {weapon.HandsAmount} Цена {weapon.Price}{big}{wash}");
    }
}