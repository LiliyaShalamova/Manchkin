using Manchkin.Core.Generators;

namespace Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

/// <summary>
/// Снимает проклятие
/// </summary>
public class CurseBonusOtherSpell : OtherSpell, IOtherSpell
{
    internal CurseBonusOtherSpell(int price, string title, int washBonus) : base(price, title, washBonus)
    {
    }

    public void Cast(Player.Player player, ICardsGenerator<Treasure> generator)
    {
        player.RemoveCurses();
    }
}