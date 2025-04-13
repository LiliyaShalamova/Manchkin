namespace Manchkin.Core.Cards.Treasures.Spells;

/// <summary>
/// Заклинания
/// </summary>
public interface ISpell : ITreasure
{ 
    string Description { get; }
}