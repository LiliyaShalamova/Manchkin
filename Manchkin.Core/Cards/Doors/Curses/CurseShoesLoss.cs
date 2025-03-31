namespace Manchkin.Core.Cards.Doors.Curses;

/// <summary>
/// Потеря обувки
/// </summary>
public class CurseShoesLoss : Curse, ICurse
{
    internal CurseShoesLoss(string title) : base(title)
    {
    }
    
    public void Curse(Player.Player player)
    {
        player.Inventory.Legs = null;
    }
}