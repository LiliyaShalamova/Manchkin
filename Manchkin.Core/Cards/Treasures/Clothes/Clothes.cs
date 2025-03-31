namespace Manchkin.Core.Cards.Treasures.Clothes;

/// <summary>
/// Класс шмотки
/// </summary>
public abstract class Clothes : Treasure
{
    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus { get; }
    
    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig { get; }

    internal Clothes(int bonus, int price, string title, bool isBig = false, int washBonus = 0)
    {
        Bonus = bonus;
        Price = price;
        Title = title;
        IsBig = isBig;
        WashBonus = washBonus;
    }
}