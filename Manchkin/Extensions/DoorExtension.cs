using Manchkin.Core;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Extensions.CurseExtensions;
using Manchkin.Extensions.MonsterExtensions;

namespace Manchkin.Extensions;

public static class DoorExtension
{
    public static void Print(this IDoor door)
    {
        switch (door)
        {
            case IMonster monster:
                MonsterExtension.Print(monster);
                break;
            case ICurse curse:
                CurseExtension.Print(curse);
                break;
        }
    }
}