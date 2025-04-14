using Manchkin.Core.Cards.Doors;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

internal class CurseArmorLoss : ICurse
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
    public void Curse(Players.Player player)
    {
        player.Inventory.Torso = null;
    }
}
