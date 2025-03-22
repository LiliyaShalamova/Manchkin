using Manchkin.Core;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Extensions;

public static class CardExtension
{
    public static void Print(this Card card)
    {
        if (card is Monster monster)
        {
            monster.Print();
        }

        else if (card is Weapon weapon)
        {
            weapon.Print();
        }
        else if (card is Clothes clothes)
        {
            clothes.Print();
        }
        else if (card is Curse curse)
        {
            curse.Print();
        }
        else if (card is DamageBonusOtherSpell damageBonusOtherSpell)
        {
            damageBonusOtherSpell.Print();
        }
        else if (card is MonstersDeathOtherSpell monstersDeathOtherSpell)
        {
            monstersDeathOtherSpell.Print();
        }
        else if (card is WashBonusOtherSpell washBonusOtherSpell)
        {
            washBonusOtherSpell.Print();
        }
        else if (card is CurseBonusOtherSpell curseBonusOtherSpell)
        {
            curseBonusOtherSpell.Print();
        }
        else if (card is LevelOtherSpell levelOtherSpell)
        {
            levelOtherSpell.Print();
        }
        else if (card is TreasuresBonusOtherSpell treasuresBonusOtherSpell)
        {
            treasuresBonusOtherSpell.Print();
        }
    }
}