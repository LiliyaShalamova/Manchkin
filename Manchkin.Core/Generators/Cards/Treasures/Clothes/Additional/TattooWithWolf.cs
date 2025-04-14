using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;

internal class TattooWithWolf : IAdditional
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 600;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Татуировка с волком";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus { get; set; } = 2;

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig { get; set; } = false;

    public TattooWithWolf()
    {
        
    }
}