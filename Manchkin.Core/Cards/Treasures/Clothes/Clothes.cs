namespace Manchkin.Core;

/// <summary>
/// Класс шмотки
/// </summary>
public class Clothes : Treasure
{
    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus { get; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; }
    
    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig { get; }
    
    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int Wash { get; }

    public Clothes(int bonus, int price, string title, bool isBig = false, int wash = 0)
    {
        Bonus = bonus;
        Price = price;
        Title = title;
        IsBig = isBig;
        Wash = wash;
    }
}