using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

internal class MiningFarmFightingSpell : IFightingSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 400;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Майнинг-ферма";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 2;
    
    public void Cast(Fight fight)
    {
        fight.WashBonus -= WashBonus;
    }
    
    public string Description => $"Бонус на смывку {WashBonus}";
}