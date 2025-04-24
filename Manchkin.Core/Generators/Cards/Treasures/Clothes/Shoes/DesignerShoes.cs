using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;

/// <summary>
/// Обувка
/// </summary>
internal class DesignerShoes : IShoes
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price => 700;

    /// <summary>
    /// Название
    /// </summary>
    public string Title => "Дизайнерские лапти";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus => 0;

    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus => 4;

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig => false;
}