using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;

public class TheTsarBell : IWeapon
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 500;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Царь-колокол";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 1;

    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus { get; set; } = 3;

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig { get; set; } =  true;

    public int HandsAmount => 1;

    public TheTsarBell()
    {
        
    }
}