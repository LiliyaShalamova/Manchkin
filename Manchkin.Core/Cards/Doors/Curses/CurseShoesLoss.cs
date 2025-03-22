namespace Manchkin.Core;

/// <summary>
/// Потеря обувки
/// </summary>
public class CurseShoesLoss : Curse, ICurse
{
    public CurseShoesLoss(string title) : base(title)
    {
    }
    
    public void Curse(Player player)
    {
        player.Inventory.Legs = null;
    }
}