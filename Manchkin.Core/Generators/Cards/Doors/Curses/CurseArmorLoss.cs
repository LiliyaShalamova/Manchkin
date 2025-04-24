using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

internal class CurseArmorLoss : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title => "Генномодифицированная моль! Потеряй надетый броник";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse => true;

    public void Curse(Player player)
    {
        player.Inventory.Torso = null;
    }
}
