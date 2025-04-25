using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Core;

internal class Fight : IFight
{
    /// <summary>
    /// Игрок в бою
    /// </summary>
    public Player Player { get; }

    /// <summary>
    /// Монстры в бою
    /// </summary>
    public List<IMonster> Monsters { get; }

    /// <summary>
    /// При броске кубика на _washBonus и выше - смываемся
    /// </summary>
    public int WashBonus { get; set; } = 5;

    public int FightingStrengthBonus { get; private set; }

    internal Fight(Player player, IMonster monster)
    {
        Player = player;
        Monsters =
        [
            monster
        ];
    }

    public void AddMonster(IMonster monster)
    {
        Monsters.Add(monster);
    }

    public void AddFightingStrength(int strength)
    {
        FightingStrengthBonus += strength;
    }
}