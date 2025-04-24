using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

/// <summary>
/// Потеря обувки
/// </summary>
internal class CurseShoesLoss : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title => "Цемент не схватился! Потеряй надетую обувку!";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse => true;

    public void Curse(Player player)
    {
        player.Inventory.Legs = null;
    }
}