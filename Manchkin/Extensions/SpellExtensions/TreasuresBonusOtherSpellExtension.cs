using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Extensions;

public static class TreasuresBonusOtherSpellExtension
{
    public static void Print(this TreasuresBonusOtherSpell treasuresBonusOtherSpell)
    {
        OtherSpellExtension.Print(treasuresBonusOtherSpell);
        var treasures = $" Возьми сокровища {treasuresBonusOtherSpell.TreasuresBonus}";
        Console.WriteLine(treasures);
    }
}