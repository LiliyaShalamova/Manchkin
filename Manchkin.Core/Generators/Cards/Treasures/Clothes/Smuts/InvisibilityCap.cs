using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;

internal class InvisibilityCap : ISmut
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price => 300;

    /// <summary>
    /// Название
    /// </summary>
    public string Title => "Шапка-невидимка";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus => 1;

    /// <summary>
    /// Бонус к боевой силе
    /// </summary>
    public int Bonus => 1;

    /// <summary>
    /// 0 - шмотка маленькая, 1 - шмотка большая
    /// </summary>
    public bool IsBig => false;
}