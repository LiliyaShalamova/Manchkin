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

    public override void Print()
    {
        var wash = WashBonus != 0 ? $" Бонус на смывку {WashBonus}" : "";
        var damage = DamageBonus != 0 ? $" Бонус против монстра {DamageBonus}" : "";
        var death = MonstersDeath ? $" Смерть монстра" : "";
        Console.WriteLine($"{Title} Цена {Price}{wash}{damage}{death}");
    }
}