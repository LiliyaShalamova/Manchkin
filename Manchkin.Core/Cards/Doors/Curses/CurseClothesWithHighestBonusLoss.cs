namespace Manchkin.Core;

/// <summary>
/// Потеря шмотки с наибольшим бонусом
/// </summary>
public class CurseClothesWithHighestBonusLoss : Curse, ICurse
{
    public CurseClothesWithHighestBonusLoss(string title) : base(title)
    {
    }
    
    public void Curse(Player player)
    {
        throw new NotImplementedException();
    }
}