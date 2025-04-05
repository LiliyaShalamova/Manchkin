using Manchkin.Core;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Generators;
using Manchkin.Core.Player;

namespace Manchkin.Cards;

public class TreasureOtherSpell : IOtherSpell
{
    public void Cast(Player player, ICardsGenerator<ITreasure> generator)
    {
        player.Cards.Add(generator.GetCard());
    }

    public string Title { get; init; }
    public int Price { get; init; }
    public int WashBonus { get; init; }
}