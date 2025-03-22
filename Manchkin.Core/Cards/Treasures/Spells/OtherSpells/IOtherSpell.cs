using Manchkin.Core.Generators;

namespace Manchkin.Core.Cards.Treasures.Spells;

public interface IOtherSpell
{
    public void Cast(Player player, ICardsGenerator<Treasure> generator);
}