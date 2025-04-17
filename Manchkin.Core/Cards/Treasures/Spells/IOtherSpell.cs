using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;
using Manchkin.Core.Players;

namespace Manchkin.Core.Cards.Treasures.Spells;

public interface IOtherSpell : ISpell
{ 
    CommandResultWith<bool> Cast(Player player, ICardsGenerator generator);
}