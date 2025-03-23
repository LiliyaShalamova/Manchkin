using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Extensions;

public static class PlayerClassLossMonsterExtension
{
    public static void Print(this PlayerClassLossMonster playerClassLossMonster)
    {
        MonsterExtension.Print(playerClassLossMonster);
        var loss = ", при проигрыше потеря класса";
        Console.WriteLine(loss);
    }
}