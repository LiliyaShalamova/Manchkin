namespace Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

/// <summary>
/// Бонус против монстра в бою
/// </summary>
public class DamageBonusOtherSpell : FightingSpell, IFightingSpell
{
    /// <summary>
    /// + против монстра
    /// </summary>
    public int DamageBonus { get;}
    
    internal DamageBonusOtherSpell(int price, string title, int washBonus, int damageBonus) : base(price, title, washBonus)
    {
        DamageBonus = damageBonus;
    }

    public void Cast(Fight fight)
    {
        fight.AddFightingStrength(DamageBonus);
    }
}