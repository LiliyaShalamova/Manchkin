using Manchkin.Core.Generators;

namespace Manchkin.Core.Cards.Treasures.Spells;

public class TreasuresBonusOtherSpell : OtherSpell, IOtherSpell
{
    /// <summary>
    /// Количество сокровищ
    /// </summary>
    public int TreasuresBonus { get;}
    
    public TreasuresBonusOtherSpell(int price, string title, int washBonus, int treasuresBonus) : base(price, title, washBonus)
    {
    }

    public void Cast(Player player, ICardsGenerator<Treasure> generator)
    {
        for (var i = 0; i < TreasuresBonus; i++)
        {
            player.Cards.Add(generator.GetCard());
        }
    }

    /*public override void Print()
    {
        base.Print();
        var treasures = $" Возьми сокровища {TreasuresBonus}";
        Console.WriteLine(treasures);
    }*/
}