using Manchkin.Core.Generators.Cards.Doors.Monsters;

namespace Manchkin.Extensions.MonsterExtensions;

public static class IvanTheTerribleMonsterExtension
{
    public static void Print(this IvanTheTerrible armorLossMonster)
    {
        MonsterExtension.Print(armorLossMonster);
        var loss = ", при проигрыше потеря броника";
        Console.WriteLine(loss);
    }
}