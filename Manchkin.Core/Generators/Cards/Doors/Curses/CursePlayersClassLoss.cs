using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

/// <summary>
/// Потеря класса
/// </summary>
internal class CursePlayersClassLoss : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title => "Инфляция! Потеряй класс!";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get; init; } = true;

    public void Curse(Player player)
    {
        player.LoseClass();
    }
}