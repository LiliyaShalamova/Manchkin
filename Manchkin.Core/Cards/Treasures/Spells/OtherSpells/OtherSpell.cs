namespace Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

public class OtherSpell : Spell
{
    internal OtherSpell(int price, string title, int washBonus)
    {
        Price = price;
        Title = title;
        WashBonus = washBonus;
    }
}