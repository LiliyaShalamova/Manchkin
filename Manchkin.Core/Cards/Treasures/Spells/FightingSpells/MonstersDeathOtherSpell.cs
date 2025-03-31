namespace Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

/// <summary>
/// Смерть монстров в бою
/// </summary>
public class MonstersDeathOtherSpell : FightingSpell, IFightingSpell
{
    internal MonstersDeathOtherSpell(int price, string title, int washBonus) : base(price, title, washBonus)
    {
    }

    public void Cast(Fight fight)
    {
        fight.Monsters.Clear();
    }
}