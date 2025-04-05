using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Extensions.MonsterExtensions;

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