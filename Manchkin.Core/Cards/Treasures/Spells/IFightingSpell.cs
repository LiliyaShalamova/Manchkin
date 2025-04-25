using Manchkin.Core.Players;

namespace Manchkin.Core.Cards.Treasures.Spells;

public interface IFightingSpell : ISpell
{ 
    void Cast(IFight fight);
}