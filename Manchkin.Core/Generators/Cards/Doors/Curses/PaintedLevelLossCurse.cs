using Manchkin.Core.Cards.Doors.Curses;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

/// <summary>
/// Потеря уровня
/// </summary>
public class PaintedLevelLossCurse : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; init; } = "Окрашено! Потеряй уровень!";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get; init; } = true;

    /// <summary>
    /// Количество уровней
    /// </summary>
    private int LevelLossCount => 1;

    public PaintedLevelLossCurse()
    {
        
    }
    public void Curse(Player.Player player)
    {
        player.DecreaseLevel(LevelLossCount);
    }
}