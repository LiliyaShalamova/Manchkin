using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Extensions;

public static class LevelLossMonsterExtension
{
    public static void Print(this LevelLossMonster levelLossMonster)
    {
        MonsterExtension.Print(levelLossMonster);
        var loss = $", при проигрыше количество потерянных уровней: {levelLossMonster.LevelLossCount}";
        Console.WriteLine(loss);
    }
}