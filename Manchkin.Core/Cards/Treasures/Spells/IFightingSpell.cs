namespace Manchkin.Core.Cards.Treasures.Spells;

public interface IFightingSpell : ISpell
{ 
    void Cast(Fight fight);
}