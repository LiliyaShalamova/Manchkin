namespace Manchkin.Core.Cards.Treasures;

/// <summary>
/// Класс сокровищ
/// </summary>
public abstract class Treasure : Card
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; protected init; }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; protected init; }
    
    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; protected init; }
}