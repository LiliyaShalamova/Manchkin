namespace Manchkin.Core.Cards.Doors;

public interface IMonster : IDoor
{
    /// <summary>
    /// Уровень
    /// </summary>
    int Level { get; }

    /// <summary>
    /// Награда за победу над монстром - количество сокровищ
    /// </summary>
    int TreasuresCount { get; }

    /// <summary>
    /// Количество уровней за победу над монстром
    /// </summary>
    int LevelsCount { get; }

    /// <summary>
    /// Уровень игрока - начиная с этого уровня и ниже не сражается
    /// </summary>
    int DoesNotFightLevel { get; }

    void Punish(Players.Player player);
    
    string Description {get;}
}