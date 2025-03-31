using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

namespace Manchkin.Extensions;

public static class FightingSpellExtension
{
    public static void Print(this FightingSpell fightingSpell)
    {
        var wash = fightingSpell.WashBonus != 0 ? $" Бонус на смывку {fightingSpell.WashBonus}" : "";
        Console.Write($"{fightingSpell.Title} Цена {fightingSpell.Price}{wash} ");
    }
}