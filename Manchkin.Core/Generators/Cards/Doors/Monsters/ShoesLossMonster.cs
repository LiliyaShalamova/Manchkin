using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Doors.Monsters;

internal class ShoesLossMonster : IMonster
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level => 3;

    /// <summary>
    /// Имя
    /// </summary>
    public string Title => "Обувная моль";

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
    public int DoesNotFightLevel => 0;

    public void Punish(Player player)
    {
        player.Inventory.Legs = null;
    }
    
    public string Description => "При проигрыше потеря обувки";
}