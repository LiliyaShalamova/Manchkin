using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;

namespace Manchkin.Extensions.ClothesExtensions;

public static class WeaponExtension
{
    public static void Print(this IWeapon swordLollipop)
    {
        var big = swordLollipop.IsBig ? " Большая" : string.Empty;
        var wash = swordLollipop.WashBonus != 0 ? $" Бонус на смывку {swordLollipop.WashBonus}" : string.Empty;
        Console.WriteLine($"{swordLollipop.Title} Бонус {swordLollipop.Bonus} Количество рук {swordLollipop.HandsAmount} Цена {swordLollipop.Price}{big}{wash}");
    }
}