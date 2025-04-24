using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Doors.Monsters;

internal class Viy : IMonster
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level => 6;

    /// <summary>
    /// Имя
    /// </summary>
    public string Title => "Вий";

    /// <summary>
    /// Награда за победу над монстром - количество сокровищ
    /// </summary>
    public int TreasuresCount => 2;

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
    
    public void Punish(Player player)
    {
        player.DecreaseLevel(LevelLossCount);
    }
    
    public string Description => $"При проигрыше потеря уровней {LevelLossCount}";
}