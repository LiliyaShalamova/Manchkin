using Manchkin.Core.Cards.Doors;

namespace Manchkin.Extensions.MonsterExtensions;

public static class MonsterExtension
{
    public static void Print(this IMonster monster)
    {
        var victoryReward =
            $"награда за победу: количество сокровищ {monster.TreasuresCount}, количество уровней {monster.LevelsCount}";
        var doesNotFightLevel = monster.DoesNotFightLevel != 0 ? $"не сражается с игроками {monster.DoesNotFightLevel} уровня и ниже, " : "";
        Console.WriteLine($"Карта Монстр. Имя: {monster.Title}, уровень {monster.Level}, {doesNotFightLevel}{victoryReward}. {monster.Description}");
    }
}