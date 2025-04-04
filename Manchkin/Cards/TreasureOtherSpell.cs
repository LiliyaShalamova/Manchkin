using Manchkin.Core;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Generators;
using Manchkin.Core.Player;

namespace Manchkin.Cards;

public class TreasureOtherSpell : Spell, IOtherSpell
{
    public void Cast(Player player, ICardsGenerator<Treasure> generator)
    {
        player.Cards.Add(generator.GetCard());
    }
}