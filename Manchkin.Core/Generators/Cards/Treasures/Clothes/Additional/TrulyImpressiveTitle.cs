using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;

internal class TrulyImpressiveTitle : IAdditional
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price => 0;

    /// <summary>
    /// Название
    /// </summary>
    public string Title => "Реально впечатляющий титул";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus => 0;

    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus => 3;

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig => false;
}