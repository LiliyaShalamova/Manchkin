using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

/// <summary>
/// Бонус на смывку
/// </summary>
internal class ThePowerOfKsivaFightingSpell : IFightingSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 300;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Сила ксивы";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 1;
    
    public void Cast(Fight fight)
    {
        fight.WashBonus -= WashBonus;
    }
    
    public string Description => $"Бонус на смывку {WashBonus}";
}