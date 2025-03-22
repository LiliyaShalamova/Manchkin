namespace Manchkin.Core.Cards.Treasures.Spells;

/// <summary>
/// Смерть монстров в бою
/// </summary>
public class MonstersDeathOtherSpell : FightingSpell, IFightingSpell
{
    public MonstersDeathOtherSpell(int price, string title, int washBonus) : base(price, title, washBonus)
    {
    }

    public void Cast(Fight fight)
    {
        fight.Monsters.Clear();
    }

    /*public override void Print()
    {
        base.Print();
        var death = " Смерть монстра";
        Console.WriteLine(death);
    }*/
}