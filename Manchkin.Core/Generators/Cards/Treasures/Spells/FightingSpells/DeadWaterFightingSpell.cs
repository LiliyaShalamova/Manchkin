using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

/// <summary>
/// Смерть монстров в бою
/// </summary>
public class DeadWaterFightingSpell : IFightingSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 800;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Мёртвая вода";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    public DeadWaterFightingSpell()
    {
        
    }
    public void Cast(Fight fight)
    {
        fight.Monsters.Clear();
    }
    
    public string Description => $"Смерть монстра";
}