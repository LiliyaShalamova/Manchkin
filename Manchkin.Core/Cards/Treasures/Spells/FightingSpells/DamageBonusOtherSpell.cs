namespace Manchkin.Core.Cards.Treasures.Spells;

/// <summary>
/// Бонус против монстра в бою
/// </summary>
public class DamageBonusOtherSpell : FightingSpell, IFightingSpell
{
    /// <summary>
    /// + против монстра
    /// </summary>
    public int DamageBonus { get;}
    
    public DamageBonusOtherSpell(int price, string title, int washBonus, int damageBonus) : base(price, title, washBonus)
    {
        DamageBonus = damageBonus;
    }

    public void Cast(Fight fight)
    {
        fight.AddFightingStrength(DamageBonus);
    }
    
    /*public override void Print()
    {
        base.Print();
        var damage = DamageBonus != 0 ? $" Бонус против монстра {DamageBonus}" : "";
        Console.WriteLine(damage);
    }*/
}