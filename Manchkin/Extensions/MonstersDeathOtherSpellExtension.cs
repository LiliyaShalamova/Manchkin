using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Extensions;

public static class MonstersDeathOtherSpellExtension
{
    public static void Print(this MonstersDeathOtherSpell monstersDeathOtherSpell)
    {
        FightingSpellExtension.Print(monstersDeathOtherSpell);
        var death = " Смерть монстра";
        Console.WriteLine(death);
    }
}