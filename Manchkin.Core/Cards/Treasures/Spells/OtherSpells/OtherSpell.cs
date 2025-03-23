namespace Manchkin.Core.Cards.Treasures.Spells;

public class OtherSpell : Spell
{
    public OtherSpell(int price, string title, int washBonus)
    {
        Price = price;
        Title = title;
        WashBonus = washBonus;
    }
}