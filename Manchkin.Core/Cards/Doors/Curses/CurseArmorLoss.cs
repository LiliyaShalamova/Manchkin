namespace Manchkin.Core.Cards.Doors.Curses;

public class CurseArmorLoss : Curse, ICurse
{
    internal CurseArmorLoss(string title) : base(title)
    {
    }
    
    public void Curse(Player.Player player)
    {
        player.Inventory.Torso = null; // прям там затираем или надо чтобы одежка была приватной и через публичный метод выкидываем шмотку?
    }
}
