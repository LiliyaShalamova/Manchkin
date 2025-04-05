namespace Manchkin.Core.Cards.Doors.Curses;

public interface ICurse : IDoor
{
    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get; init; }

    void Curse(Player.Player player);
}