using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Game.States;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

/// <summary>
/// Снимает проклятие
/// </summary>
internal class WantedRingOtherSpell : IOtherSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price => 500;

    /// <summary>
    /// Название
    /// </summary>
    public string Title => "Хотельное кольцо";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus => 0;
    
    public CommandResultWith<bool> Cast(Player player, ICardsGenerator generator)
    {
        player.RemoveCurses();
        return new CommandResultWith<bool>(true, true);
    }
    
    public string Description => "Снимает проклятие";
}