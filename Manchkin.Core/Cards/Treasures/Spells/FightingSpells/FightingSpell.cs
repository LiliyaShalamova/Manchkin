namespace Manchkin.Core.Cards.Treasures.Spells;

/// <summary>
/// Заклинания, используемые в бою
/// </summary>
public class FightingSpell : Spell
{
    public FightingSpell(int price, string title, int washBonus)
    {
        WashBonus = washBonus;
        Price = price;
        Title = title;
    }
}