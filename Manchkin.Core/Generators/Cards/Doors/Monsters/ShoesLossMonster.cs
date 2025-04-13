using Manchkin.Core.Cards.Doors;

namespace Manchkin.Core.Generators.Cards.Doors.Monsters;

public class ShoesLossMonster : IMonster
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level { get; } = 3;
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Title { get; init; } = "Обувная моль";

    /// <summary>
    /// Награда за победу над монстром - количество сокровищ
    /// </summary>
    public int TreasuresCount { get; } = 1;

    /// <summary>
    /// Количество уровней за победу над монстром
    /// </summary>
    public int LevelsCount { get; } = 1;

    /// <summary>
    /// Уровень игрока - начиная с этого уровня и ниже не сражается
    /// </summary>
    public int DoesNotFightLevel { get; } = 0;
    
    public ShoesLossMonster()
    {
    }

    public void Punish(Players.Player player)
    {
        player.Inventory.Legs = null;
    }
    
    public string Description => $"При проигрыше потеря обувки";
}