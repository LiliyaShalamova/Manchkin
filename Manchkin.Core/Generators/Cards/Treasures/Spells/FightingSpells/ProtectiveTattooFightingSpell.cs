﻿using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

internal class ProtectiveTattooFightingSpell : IFightingSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 1000;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Защитная татуировка";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus { get; init; } = 0;
    
    public void Cast(IFight fight)
    {
        fight.Monsters.Clear();
    }
    
    public string Description => $"Смерть монстра";
}