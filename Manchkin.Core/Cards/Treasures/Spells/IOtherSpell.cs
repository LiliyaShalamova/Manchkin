using Manchkin.Core.Generators;
using Manchkin.Core.Players;

namespace Manchkin.Core.Cards.Treasures.Spells;

public interface IOtherSpell : ISpell
{ 
    void Cast(Players.Player player, ICardsGenerator generator);
}