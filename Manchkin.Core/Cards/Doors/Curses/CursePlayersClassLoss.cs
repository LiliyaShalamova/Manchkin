namespace Manchkin.Core;

/// <summary>
/// Потеря класса
/// </summary>
public class CursePlayersClassLoss : Curse, ICurse
{
    public CursePlayersClassLoss(string title) : base(title)
    {
    }
    
    public void Curse(Player player)
    {
        player.LoseClass();
    }
}