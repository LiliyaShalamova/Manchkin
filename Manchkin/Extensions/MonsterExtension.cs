using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Extensions;

public static class MonsterExtension
{
    public static void Print(this Monster monster)
    {
        var victoryReward =
            $"награда за победу: количество сокровищ {monster.TreasuresCount}, количество уровней {monster.LevelsCount}";
        var loss = (monster.Death ? "смерть" : "") +
                   (monster.LevelLossCount != 0 ? $"количество потерянных уровней {monster.LevelLossCount}" : "") +
                   (monster.PlayerClassLoss ? "потеря класса" : "") +
                   (monster.ShoesLoss ? "потеря обувки" : "") +
                   (monster.ArmorLoss ? "потеря броника" : "");
        var doesNotFightLevel = monster.DoesNotFightLevel != 0 ? $"не сражается с игроками {monster.DoesNotFightLevel} уровня и ниже," : "";
        Console.WriteLine($"Карта Монстр. Имя: {monster.Name}, уровень {monster.Level},{doesNotFightLevel} {victoryReward}, при проигрыше: {loss}");
    }
}