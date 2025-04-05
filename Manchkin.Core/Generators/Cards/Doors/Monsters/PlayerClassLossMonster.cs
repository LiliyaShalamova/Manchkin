using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Core.Generators.Cards.Doors.Monsters;

public class PlayerClassLossMonster : IMonster
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level { get; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Title { get; init; }
    
    /// <summary>
    /// Награда за победу над монстром - количество сокровищ
    /// </summary>
    public int TreasuresCount { get; }
    
    /// <summary>
    /// Количество уровней за победу над монстром
    /// </summary>
    public int LevelsCount { get; }
    
    /// <summary>
    /// Уровень игрока - начиная с этого уровня и ниже не сражается
    /// </summary>
    public int DoesNotFightLevel { get; }
    
    public PlayerClassLossMonster()
    {
    }

    public void Punish(Player.Player player)
    {
        player.LoseClass();
    }
}