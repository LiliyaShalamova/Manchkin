﻿using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;

internal class BorschtPackageFightingSpell : IFightingSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price { get; init; } = 200;

    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; } = "Борщпакет";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus => 0;

    /// <summary>
    /// + против монстра
    /// </summary>
    public int DamageBonus { get; } = 4;
    
    public void Cast(IFight fight)
    {
        fight.AddFightingStrength(DamageBonus);
    }

    public string Description => $"Бонус против монстра {DamageBonus}";
}