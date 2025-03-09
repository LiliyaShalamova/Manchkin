namespace Manchkin.Core;

/// <summary>
/// Класс игрока
/// </summary>
public class Player
{
    /// <summary>
    /// Пол
    /// </summary>
    public Sex Sex { get; private set; }
    
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level { get; private set; }
    
    
    public Class? MainClass { get; private set; }
    public Class? AdditionalClass { get; private set; }
    public Race? Race { get; private set; }
    public Color Color { get; private set; }
    public bool IsSuperManchkin { get; private set; }
    public Curse[] Curses { get; private set; }
    public Inventory Inventory { get; private set; }
}