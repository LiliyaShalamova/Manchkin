namespace Manchkin.Core.Cards.Treasures.Clothes;

/// <summary>
/// Головняк
/// </summary>
public class Ukokoshnik : IClothes
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 600;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Укокошник";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus { get; set; } = 3;

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig { get; set; } = false;

    public Ukokoshnik()
    {
        
    }
}