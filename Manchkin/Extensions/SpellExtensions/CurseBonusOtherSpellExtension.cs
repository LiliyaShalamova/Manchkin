using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Extensions;

public static class CurseBonusOtherSpellExtension
{
    public static void Print(this CurseBonusOtherSpell curseBonusOtherSpell)
    {
        OtherSpellExtension.Print(curseBonusOtherSpell);
        var curse = " Снимает проклятие";
        Console.WriteLine(curse);
    }
}