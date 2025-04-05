using Manchkin.Core.Cards.Doors.Curses;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

/// <summary>
/// Потеря обувки
/// </summary>
public class CurseShoesLoss : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; init; } = "Цемент не схватился! Потеряй надетую обувку!";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get; init; } = true;

    public CurseShoesLoss()
    {
        
    }
    public void Curse(Player.Player player)
    {
        player.Inventory.Legs = null;
    }
}