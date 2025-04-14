using Manchkin.Core.Cards.Doors;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

internal class CutOffTheBranchLevelLossCurse : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; init; } = "Сруби сук, на котором сидишь! Потеряй уровень";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get; init; } = true;

    /// <summary>
    /// Количество уровней
    /// </summary>
    private int LevelLossCount => 1;

    public CutOffTheBranchLevelLossCurse()
    {
        
    }
    public void Curse(Players.Player player)
    {
        player.DecreaseLevel(LevelLossCount);
    }
}