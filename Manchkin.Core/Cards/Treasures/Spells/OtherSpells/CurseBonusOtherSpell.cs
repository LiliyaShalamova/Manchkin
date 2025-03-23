using Manchkin.Core.Generators;

namespace Manchkin.Core.Cards.Treasures.Spells;

/// <summary>
/// Снимает проклятие
/// </summary>
public class CurseBonusOtherSpell : OtherSpell, IOtherSpell
{
    public CurseBonusOtherSpell(int price, string title, int washBonus) : base(price, title, washBonus)
    {
    }

    public void Cast(Player player, ICardsGenerator<Treasure> generator)
    {
        player.RemoveCurses();
    }
}