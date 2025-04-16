using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;

internal class ReallyFastRunningShoes : IShoes
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 400;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Башмаки реально быстрого бега";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 2;

    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus { get; set; } = 0;

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig { get; set; } = false;
}