using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

namespace Manchkin.Extensions;

public static class DamageBonusOtherSpellExtension
{
    public static void Print(this DamageBonusOtherSpell spell)
    {
        FightingSpellExtension.Print(spell);
        var damage = spell.DamageBonus != 0 ? $" Бонус против монстра {spell.DamageBonus}" : "";
        Console.WriteLine(damage);
    }
}