using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

public class TreasuresBonusOtherSpell : IOtherSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } // TODO почему тут init не может быть protected

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Возьми сокровище!";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 2;

    /// <summary>
    /// Количество сокровищ
    /// </summary>
    public int TreasuresBonus { get; } = 1;

    public TreasuresBonusOtherSpell()
    {
        
    }
    public void Cast(Player.Player player, ICardsGenerator<ITreasure> generator)
    {
        for (var i = 0; i < TreasuresBonus; i++)
        {
            player.Cards.Add(generator.GetCard());
        }
    }
}