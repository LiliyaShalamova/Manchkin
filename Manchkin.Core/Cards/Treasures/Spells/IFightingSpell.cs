namespace Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

public interface IFightingSpell : ISpell
{
    internal void Cast(Fight fight);
}