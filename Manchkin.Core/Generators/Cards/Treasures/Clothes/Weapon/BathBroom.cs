﻿using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;

internal class BathBroom : IWeapon
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 400;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Банный веник";

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
    public bool IsBig { get; set; } =  false;

    public int HandsAmount => 1;
}