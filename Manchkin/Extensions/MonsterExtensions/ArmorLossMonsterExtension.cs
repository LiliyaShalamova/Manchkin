using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Extensions;

public static class ArmorLossMonsterExtension
{
    public static void Print(this ArmorLossMonster armorLossMonster)
    {
        MonsterExtension.Print(armorLossMonster);
        var loss = ", при проигрыше потеря броника";
        Console.WriteLine(loss);
    }
}