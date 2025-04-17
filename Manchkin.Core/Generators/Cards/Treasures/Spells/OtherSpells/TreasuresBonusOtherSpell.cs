using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Game.States;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

internal class TreasuresBonusOtherSpell : IOtherSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price => 0;

    /// <summary>
    /// Название
    /// </summary>
    public string Title => "Возьми сокровище!";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus => 0;

    /// <summary>
    /// Количество сокровищ
    /// </summary>
    private int TreasuresBonus => 1;

    public CommandResultWith<bool> Cast(Player player, ICardsGenerator generator)
    {
        for (var i = 0; i < TreasuresBonus; i++)
        {
            player.Cards = player.Cards.Add(generator.GetTreasureCard());
        }
        return new CommandResultWith<bool>(true, true);
    }
    
    public string Description => $"Возьми сокровище: {TreasuresBonus}";
}