using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Game.States;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

internal class ResolveCubanMissileCrisisGetLevelOtherSpell : IOtherSpell
{
    /// <summary>
    /// Цена
    /// </summary>
    public int Price => 0;

    /// <summary>
    /// Название
    /// </summary>
    public string Title => "Разреши Карибский кризис. Получи уровень!";

    /// <summary>
    /// Бонус на смывку
    /// </summary>
    public int WashBonus => 0;

    /// <summary>
    /// Получи уровень
    /// </summary>
    public int LevelBonus => 1;
    
    public CommandResultWith<bool> Cast(Player player, ICardsGenerator generator)
    {
        if (player.Level + LevelBonus >= 10) // заменить 10 на значение из конфига
        {
            return new CommandResultWith<bool>(true, false);
        }
        player.IncreaseLevel(LevelBonus);
        return new CommandResultWith<bool>(true, true);
    }
    
    public string Description => $"Получи уровень: {LevelBonus}";
}