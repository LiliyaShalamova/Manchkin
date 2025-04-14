using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

/// <summary>
/// Снимает проклятие
/// </summary>
internal class WantedRingOtherSpell : IOtherSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 500;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Хотельное кольцо";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    public WantedRingOtherSpell()
    {
        
    }
    public void Cast(Players.Player player, ICardsGenerator generator)
    {
        player.RemoveCurses();
    }
    
    public string Description => $"Снимает проклятие";
}