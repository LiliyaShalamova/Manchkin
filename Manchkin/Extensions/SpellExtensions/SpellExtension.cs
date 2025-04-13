using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Extensions.SpellExtensions;

public static class SpellExtension
{
    public static void Print(this ISpell spell)
    {
        var wash = spell.WashBonus != 0 ? $" Бонус на смывку {spell.WashBonus}" : "";
        Console.WriteLine($"{spell.Title} Цена {spell.Price}{wash}. {spell.Description} ");
    }
}