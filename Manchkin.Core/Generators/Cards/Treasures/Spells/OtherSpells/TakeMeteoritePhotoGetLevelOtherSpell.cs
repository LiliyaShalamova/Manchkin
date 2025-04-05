using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

public class TakeMeteoritePhotoGetLevelOtherSpell : IOtherSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 0;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Сфотографируй метеорит. Получи уровень!";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    /// <summary>
    /// Получи уровень
    /// </summary>
    public int LevelBonus => 1;

    public TakeMeteoritePhotoGetLevelOtherSpell()
    {
        
    }
    public void Cast(Player.Player player, ICardsGenerator<ITreasure> generator)
    {
        player.IncreaseLevel(LevelBonus);
    }

    
}