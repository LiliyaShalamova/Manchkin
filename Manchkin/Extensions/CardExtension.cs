using Manchkin.Core;
using Manchkin.Core.Cards.Doors.Curses;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Extensions;

public static class CardExtension
{
    public static void Print(this Card card)
    {
        switch (card)
        {
            case ArmorLossMonster armorLossMonster:
                armorLossMonster.Print();
                break;
            case DeathMonster deathMonster:
                deathMonster.Print();
                break;
            case LevelLossMonster levelLossMonster:
                levelLossMonster.Print();
                break;
            case PlayerClassLossMonster playerClassLossMonster:
                playerClassLossMonster.Print();
                break;
            case ShoesLossMonster shoesLossMonster:
                shoesLossMonster.Print();
                break;
            case Weapon weapon:
                weapon.Print();
                break;
            case Clothes clothes:
                clothes.Print();
                break;
            case Curse curse:
                curse.Print();
                break;
            case DamageBonusOtherSpell damageBonusOtherSpell:
                damageBonusOtherSpell.Print();
                break;
            case MonstersDeathOtherSpell monstersDeathOtherSpell:
                monstersDeathOtherSpell.Print();
                break;
            case WashBonusOtherSpell washBonusOtherSpell:
                washBonusOtherSpell.Print();
                break;
            case CurseBonusOtherSpell curseBonusOtherSpell:
                curseBonusOtherSpell.Print();
                break;
            case LevelOtherSpell levelOtherSpell:
                levelOtherSpell.Print();
                break;
            case TreasuresBonusOtherSpell treasuresBonusOtherSpell:
                treasuresBonusOtherSpell.Print();
                break;
        }
    }
}