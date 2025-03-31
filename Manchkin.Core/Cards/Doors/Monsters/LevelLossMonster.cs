namespace Manchkin.Core.Cards.Doors.Monsters;

public class LevelLossMonster : Monster, IPunish
{
    /// <summary>
    /// При проигрыше - потеря уровней
    /// </summary>
    public int LevelLossCount { get; }
    
    internal LevelLossMonster(int level, string name, int treasuresCount, int levelsCount, int doesNotFightLevel, int levelLossCount) : base(level, name, treasuresCount, levelsCount, doesNotFightLevel)
    {
        LevelLossCount = levelLossCount;
    }

    public void Punish(Player.Player player)
    {
        player.DecreaseLevel(LevelLossCount);
    }
}