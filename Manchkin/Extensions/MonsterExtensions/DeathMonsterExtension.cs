using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Extensions.MonsterExtensions;

namespace Manchkin.Extensions;

public static class DeathMonsterExtension
{
    public static void Print(this KoscheiTheDeathless koscheiTheDeathless)
    {
        MonsterExtension.Print(koscheiTheDeathless);
        var loss = ", при проигрыше смерть";
        Console.WriteLine(loss);
    }
}