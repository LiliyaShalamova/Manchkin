using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Doors.Monsters;

internal class PlayerClassLossMonster : IMonster
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level => 4;

    /// <summary>
    /// Имя
    /// </summary>
    public string Title => "Классный монстр";

    /// <summary>
    /// Награда за победу над монстром - количество сокровищ
    /// </summary>
    public int TreasuresCount => 1;

    /// <summary>
    /// Количество уровней за победу над монстром
    /// </summary>
    public int LevelsCount => 1;

    /// <summary>
    /// Уровень игрока - начиная с этого уровня и ниже не сражается
    /// </summary>
    public int DoesNotFightLevel { get; }

    public void Punish(Player player)
    {
        player.LoseClass();
    }
    
    public string Description => "При проигрыше потеря класса";
}