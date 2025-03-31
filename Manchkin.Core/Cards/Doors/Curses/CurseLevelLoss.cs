namespace Manchkin.Core.Cards.Doors.Curses;

/// <summary>
/// Потеря уровня
/// </summary>
public class CurseLevelLoss : Curse, ICurse
{
    internal CurseLevelLoss(string title, int levelLossCount) : base(title)
    {
        LevelLossCount = levelLossCount;
    }

    /// <summary>
    /// Количество уровней
    /// </summary>
    private int LevelLossCount { get; }
    
    public void Curse(Player.Player player)
    {
        player.DecreaseLevel(LevelLossCount);
    }
}