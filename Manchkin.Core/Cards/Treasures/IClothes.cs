namespace Manchkin.Core.Cards.Treasures.Clothes;

/// <summary>
/// Интерфейс шмотки
/// </summary>
public interface IClothes : ITreasure
{
    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus { get; set; }

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig { get; set; }
    
}