using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Extensions;

public static class DeathMonsterExtension
{
    public static void Print(this DeathMonster deathMonster)
    {
        MonsterExtension.Print(deathMonster);
        var loss = ", при проигрыше смерть";
        Console.WriteLine(loss);
    }
}