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
    /// При проигрыше - смерть игрока
    /// </summary>
    public bool Death { get; }
    
    /// <summary>
    /// Уровень игрока - начиная с этого уровня и ниже не сражается
    /// </summary>
    public int DoesNotFightLevel { get; }
    
    /// <summary>
    /// При проигрыше - потеря уровней
    /// </summary>
    public int LevelLossCount { get; }
    
    /// <summary>
    /// При проигрыше - потеря класса
    /// </summary>
    public bool PlayerClassLoss { get; }
    
    /// <summary>
    /// При проигрыше - потеря обувки
    /// </summary>
    public bool ShoesLoss { get; }

    /// <summary>
    /// При проигрыше - потеря брони
    /// </summary>
    public bool ArmorLoss { get; }
    
    public Monster(int level, string name, int treasuresCount, int levelsCount, bool death, int doesNotFightLevel,
        int levelLossCount, bool playerClassLoss, bool shoesLoss, bool armorLoss)
    {
        Level = level;
        Name = name;
        TreasuresCount = treasuresCount;
        LevelsCount = levelsCount;
        Death = death;
        DoesNotFightLevel = doesNotFightLevel;
        LevelLossCount = levelLossCount;
        PlayerClassLoss = playerClassLoss;
        ShoesLoss = shoesLoss;
        ArmorLoss = armorLoss;
    }
}