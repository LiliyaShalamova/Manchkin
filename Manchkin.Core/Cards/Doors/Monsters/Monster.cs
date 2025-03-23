namespace Manchkin.Core.Cards.Doors.Monsters;

/// <summary>
/// Живой монстр
/// </summary>
public class Monster : Door
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level { get; }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; }
    
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
    
    public Monster(int level, string name, int treasuresCount, int levelsCount, int doesNotFightLevel)
    {
        Level = level;
        Name = name;
        TreasuresCount = treasuresCount;
        LevelsCount = levelsCount;
        DoesNotFightLevel = doesNotFightLevel;
    }
}