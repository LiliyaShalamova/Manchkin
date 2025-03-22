namespace Manchkin.Core;

/// <summary>
/// В руку
/// </summary>
public class Weapon : Clothes
{
    public int HandsAmount { get; }

    public Weapon(int bonus, int price, string title, bool isBig = false, int washBonus = 0, int handsAmount = 0) 
        : base(bonus, price, title, isBig, washBonus)
    {
        HandsAmount = handsAmount;
    }

    /*public override void Print()
    {
        var big = IsBig ? " Большая" : string.Empty;
        var wash = WashBonus != 0 ? $" Бонус на смывку {WashBonus}" : string.Empty;
        Console.WriteLine($"{Title} Бонус {Bonus} Количество рук {HandsAmount} Цена {Price}{big}{wash}");
    }*/
}