using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

namespace Manchkin.Extensions.SpellExtensions;

public static class FightingSpellExtension
{
    public static void Print(this IFightingSpell fightingSpell)
    {
        var wash = fightingSpell.WashBonus != 0 ? $" Бонус на смывку {fightingSpell.WashBonus}" : "";
        Console.Write($"{fightingSpell.Title} Цена {fightingSpell.Price}{wash} ");
    }
}