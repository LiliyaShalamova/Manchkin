namespace Manchkin.Core.Cards.Treasures.Spells;

public class OtherSpell : Spell
{
    public OtherSpell(int price, string title, int washBonus)
    {
        Price = price;
        Title = title;
        WashBonus = washBonus;
    }

    /*public override void Print()
    {
        var wash = WashBonus != 0 ? $" Бонус на смывку {WashBonus}" : "";
        Console.Write($"{Title} Цена {Price}{wash}");
    }*/
}