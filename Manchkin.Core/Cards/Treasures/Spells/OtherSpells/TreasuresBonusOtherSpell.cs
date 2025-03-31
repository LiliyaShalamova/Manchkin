using Manchkin.Core.Generators;

namespace Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

public class TreasuresBonusOtherSpell : OtherSpell, IOtherSpell
{
    /// <summary>
    /// Количество сокровищ
    /// </summary>
    public int TreasuresBonus { get; }
    
    internal TreasuresBonusOtherSpell(int price, string title, int washBonus, int treasuresBonus) : base(price, title, washBonus)
    {
        TreasuresBonus = treasuresBonus;
    }

    public void Cast(Player.Player player, ICardsGenerator<Treasure> generator)
    {
        for (var i = 0; i < TreasuresBonus; i++)
        {
            player.Cards.Add(generator.GetCard());
        }
    }
}