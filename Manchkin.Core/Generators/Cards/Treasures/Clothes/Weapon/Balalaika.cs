using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;

public class Balalaika : IClothes
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 600;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Балалайка";

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
    public bool IsBig { get; set; } =  false;

    public int HandsAmount => 2;

    public Balalaika()
    {
        
    }
}