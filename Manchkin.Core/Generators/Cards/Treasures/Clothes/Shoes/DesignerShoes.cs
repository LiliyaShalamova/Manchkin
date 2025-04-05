using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;

/// <summary>
/// Обувка
/// </summary>
public class DesignerShoes : IClothes
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 700;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Дизайнерские лапти";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus { get; set; } = 4;

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig { get; set; } = false;

    public DesignerShoes()
    {
        
    }
}