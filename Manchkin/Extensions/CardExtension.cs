using Manchkin.Core;
using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors.Curses;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Extensions.ClothesExtensions;
using Manchkin.Extensions.CurseExtensions;
using Manchkin.Extensions.SpellExtensions;

namespace Manchkin.Extensions;

public static class CardExtension
{
    public static void Print(this ICard card)
    {
        switch (card)
        {
            case IvanTheTerrible armorLossMonster:
                armorLossMonster.Print();
                break;
            case KoscheiTheDeathless deathMonster:
                deathMonster.Print();
                break;
            case LittleGreyWolf levelLossMonster:
                levelLossMonster.Print();
                break;
            case PlayerClassLossMonster playerClassLossMonster:
                playerClassLossMonster.Print();
                break;
            case ShoesLossMonster shoesLossMonster:
                shoesLossMonster.Print();
                break;
            case SwordLollipop weapon:
                WeaponExtension.Print(weapon);
                break;
            case IClothes clothes:
                ClothesExtension.Print(clothes);
                break;
            case ICurse curse:
                CurseExtension.Print(curse);
                break;
            case HematogenFightingSpell damageBonusOtherSpell:
                damageBonusOtherSpell.Print();
                break;
            case DeadWaterFightingSpell monstersDeathOtherSpell:
                monstersDeathOtherSpell.Print();
                break;
            case ThePowerOfKsivaFightingSpell washBonusOtherSpell:
                FightingSpellExtension.Print(washBonusOtherSpell);
                break;
            case WantedRingOtherSpell curseBonusOtherSpell:
                curseBonusOtherSpell.Print();
                break;
            case PaintGrassGetLevelOtherSpell levelOtherSpell:
                levelOtherSpell.Print();
                break;
            case TreasuresBonusOtherSpell treasuresBonusOtherSpell:
                treasuresBonusOtherSpell.Print();
                break;
        }
    }
}