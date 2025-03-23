using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Core;

public class Fight
{
    /// <summary>
    /// Игрок в бою
    /// </summary>
    public Player Player;
    
    /// <summary>
    /// Монстры в бою
    /// </summary>
    public List<Monster> Monsters;
    
    /// <summary>
    /// При броске кубика на _washBonus и выше - смываемся
    /// </summary>
    public int WashBonus = 5;
    
    public int FightingStrengthBonus = 0;

    public Fight(Player player, Monster monster)
    {
        Player = player;
        Monsters =
        [
            monster
        ];
    }

    public void AddMonster(Monster monster)
    {
        Monsters.Add(monster);
    }

    public void AddFightingStrength(int strength)
    {
        FightingStrengthBonus += strength;
    }
}