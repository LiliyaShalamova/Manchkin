namespace Manchkin.Core.Cards.Treasures.Clothes;

/// <summary>
/// Класс броника
/// </summary>
public class BulletproofVest : Clothes
{
    internal BulletproofVest(int bonus, int price, string title, bool isBig = false, int wash = 0) : base(bonus, price,
        title, isBig, wash)
    {
    }
}