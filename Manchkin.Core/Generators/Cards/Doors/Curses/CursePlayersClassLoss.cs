using Manchkin.Core.Cards.Doors;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

/// <summary>
/// Потеря класса
/// </summary>
public class CursePlayersClassLoss : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get; init; } = "Инфляция! Потеряй класс!";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get; init; } = true;
    
    public CursePlayersClassLoss()
    {
        
    }
    public void Curse(Players.Player player)
    {
        player.LoseClass();
    }
}