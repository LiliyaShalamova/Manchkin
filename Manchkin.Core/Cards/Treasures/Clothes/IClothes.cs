namespace Manchkin.Core.Cards.Treasures.Clothes;

/// <summary>
/// Интерфейс шмотки
/// </summary>
public interface IClothes : ITreasure
{
    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    int Bonus { get; }

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    bool IsBig { get; }
    
}