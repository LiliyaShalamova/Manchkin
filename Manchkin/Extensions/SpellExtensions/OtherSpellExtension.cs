using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Extensions.SpellExtensions;

public static class OtherSpellExtension
{
    public static void Print(this IOtherSpell otherSpell)
    {
        var wash = otherSpell.WashBonus != 0 ? $" Бонус на смывку {otherSpell.WashBonus}" : "";
        Console.Write($"{otherSpell.Title} Цена {otherSpell.Price}{wash}");
    }
}