using Manchkin.Core.Cards.Doors.Curses;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

public class CurseArmorLoss : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; init; } = "Генномодифицированная моль! Потеряй надетый броник";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get; init; } = true;

    public CurseArmorLoss()
    {
        
    }
    public void Curse(Player.Player player)
    {
        player.Inventory.Torso = null;
    }
}
