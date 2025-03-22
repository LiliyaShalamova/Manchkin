using Manchkin.Core;

namespace Manchkin.Extensions;

public static class ClothesExtension
{
    public static void Print(this Clothes clothes)
    {
        var big = clothes.IsBig ? " Большая" : string.Empty;
        var wash = clothes.WashBonus != 0 ? $" Бонус на смывку {clothes.WashBonus}" : string.Empty;
        Console.WriteLine($"{clothes.Title} Бонус {clothes.Bonus} Цена {clothes.Price}{big}{wash}");
    }
}