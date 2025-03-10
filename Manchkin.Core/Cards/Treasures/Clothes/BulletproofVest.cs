namespace Manchkin.Core;

/// <summary>
/// Класс броника
/// </summary>
public class BulletproofVest : Clothes
{
    public BulletproofVest(int bonus, int price, string title, bool isBig = false, int wash = 0) : base(bonus, price,
        title, isBig)
    {
    }
}