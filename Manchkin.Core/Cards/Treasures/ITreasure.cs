namespace Manchkin.Core.Cards.Treasures;

/// <summary>
/// Интерфейс сокровищ
/// </summary>
public interface ITreasure : ICard
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; protected init; }
    
    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; protected init; }
}