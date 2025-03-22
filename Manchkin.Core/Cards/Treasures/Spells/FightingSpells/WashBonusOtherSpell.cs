namespace Manchkin.Core.Cards.Treasures.Spells;

/// <summary>
/// Бонус на смывку
/// </summary>
public class WashBonusOtherSpell : FightingSpell, IFightingSpell
{
    public WashBonusOtherSpell(int price, string title, int washBonus) : base(price, title, washBonus)
    {
    }

    public void Cast(Fight fight)
    {
        fight.WashBonus -= WashBonus;
    }
}