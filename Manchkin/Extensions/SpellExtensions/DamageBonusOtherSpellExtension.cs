using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Extensions.SpellExtensions;

namespace Manchkin.Extensions;

public static class DamageBonusOtherSpellExtension
{
    public static void Print(this HematogenFightingSpell spell)
    {
        FightingSpellExtension.Print(spell);
        var damage = spell.DamageBonus != 0 ? $" Бонус против монстра {spell.DamageBonus}" : "";
        Console.WriteLine(damage);
    }
}