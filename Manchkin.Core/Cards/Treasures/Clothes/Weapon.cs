namespace Manchkin.Core.Cards.Treasures.Clothes;

/// <summary>
/// В руку
/// </summary>
public class Weapon : Clothes
{
    public int HandsAmount { get; }

    internal Weapon(int bonus, int price, string title, bool isBig = false, int washBonus = 0, int handsAmount = 0) 
        : base(bonus, price, title, isBig, washBonus)
    {
        HandsAmount = handsAmount;
    }
}