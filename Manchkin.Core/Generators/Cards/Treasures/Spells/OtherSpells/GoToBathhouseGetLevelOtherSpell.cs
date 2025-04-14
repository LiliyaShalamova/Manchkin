using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

internal class GoToBathhouseGetLevelOtherSpell : IOtherSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 0;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Иди в баню. Получи уровень!";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    /// <summary>
    /// Получи уровень
    /// </summary>
    private int LevelBonus => 1;

    public GoToBathhouseGetLevelOtherSpell()
    {
        
    }
    public void Cast(Players.Player player, ICardsGenerator generator)
    {
        player.IncreaseLevel(LevelBonus);
    }
    
    public string Description => $"Получи уровень: {LevelBonus}";
}