using Manchkin.Core.Generators;

namespace Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

public interface IOtherSpell
{
    public void Cast(Player.Player player, ICardsGenerator<Treasure> generator);
}