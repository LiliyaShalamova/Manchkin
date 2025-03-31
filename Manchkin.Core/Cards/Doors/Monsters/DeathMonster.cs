namespace Manchkin.Core.Cards.Doors.Monsters;

public class DeathMonster : Monster, IPunish
{
    internal DeathMonster(int level, string name, int treasuresCount, int levelsCount, int doesNotFightLevel) : base(level, name, treasuresCount, levelsCount, doesNotFightLevel)
    {
    }

    public void Punish(Player.Player player)
    {
        player.Die();
    }
}