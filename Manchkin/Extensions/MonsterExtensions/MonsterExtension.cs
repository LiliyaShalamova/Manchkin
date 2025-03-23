using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Extensions;

public static class MonsterExtension
{
    public static void Print(this Monster monster)
    {
        var victoryReward =
            $"награда за победу: количество сокровищ {monster.TreasuresCount}, количество уровней {monster.LevelsCount}";
        var doesNotFightLevel = monster.DoesNotFightLevel != 0 ? $"не сражается с игроками {monster.DoesNotFightLevel} уровня и ниже," : "";
        Console.Write($"Карта Монстр. Имя: {monster.Name}, уровень {monster.Level},{doesNotFightLevel} {victoryReward}");
    }
}