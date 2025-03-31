using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Extensions;

public static class LevelOtherSpellExtension
{
    public static void Print(this LevelOtherSpell levelOtherSpell)
    {
        OtherSpellExtension.Print(levelOtherSpell);
        var level = $" Получи уровень: {levelOtherSpell.LevelBonus}";
        Console.WriteLine(level);
    }
}