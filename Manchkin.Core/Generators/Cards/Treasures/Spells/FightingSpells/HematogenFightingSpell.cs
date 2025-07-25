﻿using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

/// <summary>
/// Бонус против монстра в бою
/// </summary>
internal class HematogenFightingSpell : IFightingSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 100;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Гематоген";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;

    /// <summary>
    /// + против монстра
    /// </summary>
    public int DamageBonus { get; } = 2;
    
    public void Cast(IFight fight)
    {
        fight.AddFightingStrength(DamageBonus);
    }
    
    public string Description => $"Бонус против монстра {DamageBonus}";
}