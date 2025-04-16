using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;

internal class SportsSuit : IVest
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 500;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Спортивный костюм";

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
}