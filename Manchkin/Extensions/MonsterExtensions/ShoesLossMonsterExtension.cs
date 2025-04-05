using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Extensions.MonsterExtensions;

namespace Manchkin.Extensions;

public static class ShoesLossMonsterExtension
{
    public static void Print(this ShoesLossMonster shoesLossMonster)
    {
        MonsterExtension.Print(shoesLossMonster);
        var loss = ", при проигрыше потеря обувки";
        Console.WriteLine(loss);
    }
}