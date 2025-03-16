namespace Manchkin.Core;

/// <summary>
/// Обувка
/// </summary>
public class Shoes : Clothes
{
    public Shoes(int bonus, int price, string title, bool isBig = false, int wash = 0) : base(bonus, price, title, isBig, wash)
    {
    }
}