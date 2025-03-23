namespace Manchkin.Core;

public class Additional : Clothes
{
    public Additional(int bonus, int price, string title, bool isBig = false, int washBonus = 0) : base(bonus, price, title, isBig, washBonus)
    {
    }
}