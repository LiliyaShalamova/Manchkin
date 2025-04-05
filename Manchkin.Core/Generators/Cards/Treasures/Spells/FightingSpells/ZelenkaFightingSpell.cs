using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

public class ZelenkaFightingSpell : IFightingSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 200;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Зелёнка";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    /// <summary>
    /// + против монстра
    /// </summary>
    private int DamageBonus { get; } = 3;

    public ZelenkaFightingSpell()
    {
        
    }
    public void Cast(Fight fight)
    {
        fight.AddFightingStrength(DamageBonus);
    }
}