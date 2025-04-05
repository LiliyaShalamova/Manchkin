using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

public class FlasherFightingSpell : IFightingSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 300;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Мигалка";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    public FlasherFightingSpell()
    {
        
    }
    public void Cast(Fight fight)
    {
        fight.Monsters.Clear();
    }
}