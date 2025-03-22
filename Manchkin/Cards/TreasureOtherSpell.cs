using Manchkin.Core;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;

namespace Manchkin.Cards;

public class TreasureOtherSpell : Spell, IOtherSpell
{
    public void Cast(Player player, ICardsGenerator<Treasure> generator)
    {
        player.Cards.Add(generator.GetCard());
    }
}