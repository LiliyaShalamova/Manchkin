namespace Manchkin.Core;

/// <summary>
/// Потеря уровня
/// </summary>
public class CurseLevelLoss : Curse, ICurse
{
    public CurseLevelLoss(string title, int levelLossCount) : base(title)
    {
        LevelLossCount = levelLossCount;
    }

    /// <summary>
    /// Количество уровней
    /// </summary>
    public int LevelLossCount { get; }
    
    public void Curse(Player player)
    {
        player.DecreaseLevel(LevelLossCount);
    }
}