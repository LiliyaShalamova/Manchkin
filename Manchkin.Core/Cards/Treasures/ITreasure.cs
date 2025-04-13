namespace Manchkin.Core.Cards.Treasures;

/// <summary>
/// Интерфейс сокровищ
/// </summary>
public interface ITreasure : ICard
{
    /// <summary>
    /// Цена
    /// </summary>
    int Price { get; }
    
    /// <summary>
    /// Бонус на смывку
    /// </summary>
    int WashBonus { get; }
}