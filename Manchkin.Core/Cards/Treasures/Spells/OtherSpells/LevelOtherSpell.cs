using Manchkin.Core.Generators;

namespace Manchkin.Core.Cards.Treasures.Spells;

public class LevelOtherSpell : OtherSpell, IOtherSpell
{
    /// <summary>
    /// Получи уровень
    /// </summary>
    public int LevelBonus { get;}
    
    public LevelOtherSpell(int price, string title, int washBonus, int levelBonus) : base(price, title, washBonus)
    {
        LevelBonus = levelBonus;
    }

    public void Cast(Player player, ICardsGenerator<Treasure> generator)
    {
        player.IncreaseLevel(LevelBonus);
    }
}