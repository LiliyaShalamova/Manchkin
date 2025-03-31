namespace Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

/// <summary>
/// Заклинания, используемые в бою
/// </summary>
public class FightingSpell : Spell
{
    internal FightingSpell(int price, string title, int washBonus)
    {
        WashBonus = washBonus;
        Price = price;
        Title = title;
    }
}