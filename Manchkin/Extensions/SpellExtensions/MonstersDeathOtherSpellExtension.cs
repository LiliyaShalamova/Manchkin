using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Extensions.SpellExtensions;

namespace Manchkin.Extensions;

public static class MonstersDeathOtherSpellExtension
{
    public static void Print(this DeadWaterFightingSpell deadWaterFightingSpell)
    {
        FightingSpellExtension.Print(deadWaterFightingSpell);
        var death = " Смерть монстра";
        Console.WriteLine(death);
    }
}