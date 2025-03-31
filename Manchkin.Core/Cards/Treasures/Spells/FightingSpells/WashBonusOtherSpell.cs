namespace Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

/// <summary>
/// Бонус на смывку
/// </summary>
public class WashBonusOtherSpell : FightingSpell, IFightingSpell
{
    internal WashBonusOtherSpell(int price, string title, int washBonus) : base(price, title, washBonus)
    {
    }

    public void Cast(Fight fight)
    {
        fight.WashBonus -= WashBonus;
    }
}