using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Extensions.SpellExtensions;

namespace Manchkin.Extensions;

public static class LevelOtherSpellExtension
{
    public static void Print(this PaintGrassGetLevelOtherSpell paintGrassGetLevelOtherSpell)
    {
        OtherSpellExtension.Print(paintGrassGetLevelOtherSpell);
        var level = $" Получи уровень: {paintGrassGetLevelOtherSpell.LevelBonus}";
        Console.WriteLine(level);
    }
}