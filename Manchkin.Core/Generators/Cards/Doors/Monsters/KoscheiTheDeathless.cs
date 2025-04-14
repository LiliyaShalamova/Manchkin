using Manchkin.Core.Cards.Doors;

namespace Manchkin.Core.Generators.Cards.Doors.Monsters;

internal class KoscheiTheDeathless : IMonster
{
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level => 18;

    /// <summary>
    /// Имя
    /// </summary>
    public string Title { get; init; } = "Кощей Бессмертный";

    /// <summary>
    /// Награда за победу над монстром - количество сокровищ
    /// </summary>
    public int TreasuresCount => 5;

    /// <summary>
    /// Количество уровней за победу над монстром
    /// </summary>
    public int LevelsCount => 2;

    /// <summary>
    /// Уровень игрока - начиная с этого уровня и ниже не сражается
    /// </summary>
    public int DoesNotFightLevel => 4;

    public KoscheiTheDeathless()
    {
        
    }
    public void Punish(Players.Player player)
    {
        player.Die();
    }
    
    public string Description => $"При проигрыше смерть";
}