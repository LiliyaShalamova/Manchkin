using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

internal class HerringUnderFurCoatFightingSpell : IFightingSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 200;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Селёдка под шубой";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    /// <summary>
    /// + против монстра
    /// </summary>
    private int DamageBonus { get; } = 3;

    public HerringUnderFurCoatFightingSpell()
    {
        
    }
    public void Cast(Fight fight)
    {
        fight.AddFightingStrength(DamageBonus);
    }
    
    public string Description => $"Бонус против монстра {DamageBonus}";
}