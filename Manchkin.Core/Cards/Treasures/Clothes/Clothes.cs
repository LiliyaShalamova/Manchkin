namespace Manchkin.Core;

/// <summary>
/// Класс шмотки
/// </summary>
public class Clothes : Treasure // TODO сделать абстрактным!
{
    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus { get; }
    
    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig { get; }

    public Clothes(int bonus, int price, string title, bool isBig = false, int washBonus = 0)
    {
        Bonus = bonus;
        Price = price;
        Title = title;
        IsBig = isBig;
        WashBonus = washBonus;
    }

    /*public override void Print() // TODO вынести методы Print из Core в консольное приложение. Попробовать сделать extension методы
    {
        var big = IsBig ? " Большая" : string.Empty;
        var wash = WashBonus != 0 ? $" Бонус на смывку {WashBonus}" : string.Empty;
        Console.WriteLine($"{Title} Бонус {Bonus} Цена {Price}{big}{wash}");
    }*/
}