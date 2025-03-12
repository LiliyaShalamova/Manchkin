namespace Manchkin.Core.Cards.Treasures.Spells;

/// <summary>
/// Заклинания, используемые в бою
/// </summary>
public class FightingSpell : Spell
{
    /// <summary>
    /// + против монстра
    /// </summary>
    public int DamageBonus { get;}
    
    /// <summary>
    /// Убить монстра
    /// </summary>
    public bool MonstersDeath { get; }

    public FightingSpell(int price, string title, int washBonus, int damageBonus, bool monstersDeath)
    {
        WashBonus = washBonus;
        DamageBonus = damageBonus;
        MonstersDeath = monstersDeath;
        Price = price;
        Title = title;
    }
}