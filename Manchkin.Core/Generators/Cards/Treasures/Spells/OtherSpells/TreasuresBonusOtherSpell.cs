using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

internal class TreasuresBonusOtherSpell : IOtherSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; } = 0;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; } = "Возьми сокровище!";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; } = 0;

    /// <summary>
    /// Количество сокровищ
    /// </summary>
    public int TreasuresBonus { get; } = 1;

    public TreasuresBonusOtherSpell()
    {
        
    }
    public void Cast(Players.Player player, ICardsGenerator generator)
    {
        for (var i = 0; i < TreasuresBonus; i++)
        {
            player.Cards.Add(generator.GetTreasureCard());
        }
    }
    
    public string Description => $"Возьми сокровище: {TreasuresBonus}";
}