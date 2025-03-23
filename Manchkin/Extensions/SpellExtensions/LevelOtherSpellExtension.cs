using Manchkin.Core.Cards.Treasures.Spells;

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