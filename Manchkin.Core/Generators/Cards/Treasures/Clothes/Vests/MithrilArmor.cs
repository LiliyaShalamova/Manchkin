using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;

/// <summary>
/// Класс броника
/// </summary>
internal class MithrilArmor : IVest
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 600;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Мифрильная броня";

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
    public bool IsBig { get; set; } = false;

    public MithrilArmor()
    {
        
    }
}