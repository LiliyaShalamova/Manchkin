namespace Manchkin.Core.Cards.Doors.Monsters;

public class PlayerClassLossMonster : Monster, IPunish
{
    public PlayerClassLossMonster(int level, string name, int treasuresCount, int levelsCount, int doesNotFightLevel) : base(level, name, treasuresCount, levelsCount, doesNotFightLevel)
    {
    }

    public void Punish(Player player)
    {
        player.LoseClass();
    }
}