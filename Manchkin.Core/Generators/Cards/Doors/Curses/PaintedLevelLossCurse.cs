using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

/// <summary>
/// Потеря уровня
/// </summary>
internal class PaintedLevelLossCurse : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title => "Окрашено! Потеряй уровень!";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse => true;

    /// <summary>
    /// Количество уровней
    /// </summary>
    public int LevelLossCount => 1;
    
    public void Curse(Player player)
    {
        player.DecreaseLevel(LevelLossCount);
    }
}