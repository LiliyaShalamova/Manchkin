using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

internal class TakeMeteoritePhotoGetLevelOtherSpell : IOtherSpell
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
    public void Cast(Players.Player player, ICardsGenerator generator)
    {
        player.IncreaseLevel(LevelBonus);
    }

    public string Description => $"Получи уровень: {LevelBonus}";
}