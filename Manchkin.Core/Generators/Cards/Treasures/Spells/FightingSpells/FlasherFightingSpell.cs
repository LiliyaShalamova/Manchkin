using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

internal class FlasherFightingSpell : IFightingSpell
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
    
    public void Cast(IFight fight)
    {
        fight.Monsters.Clear();
    }
    
    public string Description => $"Смерть монстра";
}