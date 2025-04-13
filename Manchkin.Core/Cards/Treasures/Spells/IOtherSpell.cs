using Manchkin.Core.Generators;

namespace Manchkin.Core.Cards.Treasures.Spells;

public interface IOtherSpell : ISpell
{ 
    void Cast(Players.Player player, ICardsGenerator generator);
}