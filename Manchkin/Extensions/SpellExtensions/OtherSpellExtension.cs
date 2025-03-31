using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Extensions;

public static class OtherSpellExtension
{
    public static void Print(this OtherSpell otherSpell)
    {
        var wash = otherSpell.WashBonus != 0 ? $" Бонус на смывку {otherSpell.WashBonus}" : "";
        Console.Write($"{otherSpell.Title} Цена {otherSpell.Price}{wash}");
    }
}