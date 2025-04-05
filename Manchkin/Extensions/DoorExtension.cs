using Manchkin.Core;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Curses;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Extensions.CurseExtensions;

namespace Manchkin.Extensions;

public static class DoorExtension
{
    public static void Print(this IDoor door)
    {
        switch (door)
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
            case CurseArmorLoss curseArmorLoss:
                CurseExtension.Print(curseArmorLoss);
                break;
            case CurseClothesWithHighestBonusLoss curseClothesWithHighestBonusLoss:
                CurseExtension.Print(curseClothesWithHighestBonusLoss);
                break;
            case PaintedLevelLossCurse curseLevelLoss:
                CurseExtension.Print(curseLevelLoss);
                break;
            case CursePlayersClassLoss cursePlayersClassLoss:
                CurseExtension.Print(cursePlayersClassLoss);
                break;
            case CurseShoesLoss curseShoesLoss:
                CurseExtension.Print(curseShoesLoss);
                break;
        }
    }
}