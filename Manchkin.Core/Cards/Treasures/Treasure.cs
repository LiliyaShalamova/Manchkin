namespace Manchkin.Core;

/// <summary>
/// Класс сокровищ
/// </summary>
public abstract class Treasure : Card
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; protected init; } // TODO реализовать недоступность изменения из дочерних классов, кроме как из конструктора
    
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; protected init; }
    
    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; protected init; }
}