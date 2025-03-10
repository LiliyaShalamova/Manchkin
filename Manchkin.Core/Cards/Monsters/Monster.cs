namespace Manchkin.Core.Cards.Monsters;

/// <summary>
/// Живой монстр
/// </summary>
public abstract class Monster : Door
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
    public int TreasuresAmount { get; }
}