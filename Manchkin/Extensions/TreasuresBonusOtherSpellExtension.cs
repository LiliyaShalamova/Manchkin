using Manchkin.Core.Cards.Treasures.Spells;

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