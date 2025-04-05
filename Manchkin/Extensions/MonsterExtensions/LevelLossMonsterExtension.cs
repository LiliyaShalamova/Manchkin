using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Extensions.MonsterExtensions;

namespace Manchkin.Extensions;

public static class LevelLossMonsterExtension
{
    public static void Print(this LittleGreyWolf littleGreyWolf)
    {
        MonsterExtension.Print(littleGreyWolf);
        var loss = $", при проигрыше количество потерянных уровней: {littleGreyWolf.LevelLossCount}";
        Console.WriteLine(loss);
    }
}