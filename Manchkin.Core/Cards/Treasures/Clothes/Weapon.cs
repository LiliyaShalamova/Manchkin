namespace Manchkin.Core;

/// <summary>
/// В руку
/// </summary>
public class Weapon : Clothes
{
    public int HandsAmount { get; }

    public Weapon(int bonus, int price, string title, bool isBig = false, int wash = 0, int handsAmount = 0) 
        : base(bonus, price, title, isBig, wash)
    {
        HandsAmount = handsAmount;
    }
}