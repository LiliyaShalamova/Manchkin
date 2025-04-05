using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Extensions.SpellExtensions;

namespace Manchkin.Extensions;

public static class CurseBonusOtherSpellExtension
{
    public static void Print(this WantedRingOtherSpell wantedRingOtherSpell)
    {
        OtherSpellExtension.Print(wantedRingOtherSpell);
        var curse = " Снимает проклятие";
        Console.WriteLine(curse);
    }
}