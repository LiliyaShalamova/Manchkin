using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Core.Generators.Cards.Doors.Monsters;

public class BabaYaga : IMonster
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level => 18;

    /// <summary>
    /// Имя
    /// </summary>
    public string Title { get; init; } = "Баба Яга";

    /// <summary>
    /// Награда за победу над монстром - количество сокровищ
    /// </summary>
    public int TreasuresCount => 4;

    /// <summary>
    /// Количество уровней за победу над монстром
    /// </summary>
    public int LevelsCount => 2;

    /// <summary>
    /// Уровень игрока - начиная с этого уровня и ниже не сражается
    /// </summary>
    public int DoesNotFightLevel { get; } = 3;
    
    /// <summary>
    /// При проигрыше - потеря уровней
    /// </summary>
    private int LevelLossCount => 2;

    public BabaYaga()
    {
        
    }
    public void Punish(Player.Player player)
    {
        player.DecreaseLevel(LevelLossCount);
    }
}