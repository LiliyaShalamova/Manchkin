using Manchkin.Core.Cards.Doors;

namespace Manchkin.Core.Generators.Cards.Doors.Monsters;

public class IvanTheTerrible : IMonster
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level => 2;

    /// <summary>
    /// Имя
    /// </summary>
    public string Title { get; init; } = "Иван Грозный";

    /// <summary>
    /// Награда за победу над монстром - количество сокровищ
    /// </summary>
    public int TreasuresCount => 1;

    /// <summary>
    /// Количество уровней за победу над монстром
    /// </summary>
    public int LevelsCount => 1;

    /// <summary>
    /// Уровень игрока - начиная с этого уровня и ниже не сражается
    /// </summary>
    public int DoesNotFightLevel { get; }

    public IvanTheTerrible()
    {
        
    }
    public void Punish(Players.Player player)
    {
        player.Inventory.Torso = null;
    }
    
    public string Description => $"При проигрыше потеря броника";
}