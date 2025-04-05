using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Core.Generators.Cards.Doors.Monsters;

public class LittleGreyWolf : IMonster
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level => 1;

    /// <summary>
    /// Имя
    /// </summary>
    public string Title { get; init; } = "Серенький волчок";

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

    /// <summary>
    /// При проигрыше - потеря уровней
    /// </summary>
    public int LevelLossCount => 1;

    public LittleGreyWolf()
    {
        
    }
    public void Punish(Player.Player player)
    {
        player.DecreaseLevel(LevelLossCount);
    }
}