using Manchkin.Core;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Curses;
using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Extensions;

public static class DoorExtension
{
    public static void Print(this Door door)
    {
        switch (door)
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
            case CurseArmorLoss curseArmorLoss:
                curseArmorLoss.Print();
                break;
            case CurseClothesWithHighestBonusLoss curseClothesWithHighestBonusLoss:
                curseClothesWithHighestBonusLoss.Print();
                break;
            case CurseLevelLoss curseLevelLoss:
                curseLevelLoss.Print();
                break;
            case CursePlayersClassLoss cursePlayersClassLoss:
                cursePlayersClassLoss.Print();
                break;
            case CurseShoesLoss curseShoesLoss:
                curseShoesLoss.Print();
                break;
        }
    }
}