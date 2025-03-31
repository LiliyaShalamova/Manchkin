namespace Manchkin.Core.Cards.Doors.Curses;

/// <summary>
/// Потеря класса
/// </summary>
public class CursePlayersClassLoss : Curse, ICurse
{
    internal CursePlayersClassLoss(string title) : base(title)
    {
    }
    
    public void Curse(Player.Player player)
    {
        player.LoseClass();
    }
}