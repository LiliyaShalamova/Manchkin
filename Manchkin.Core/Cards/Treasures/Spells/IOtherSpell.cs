using Manchkin.Core.Generators;

namespace Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

public interface IOtherSpell : ISpell
{
    public void Cast(Player.Player player, ICardsGenerator<ITreasure> generator);
}