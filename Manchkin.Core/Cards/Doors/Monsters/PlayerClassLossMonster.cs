namespace Manchkin.Core.Cards.Doors.Monsters;

public class PlayerClassLossMonster : Monster
{
    internal PlayerClassLossMonster(int level, string name, int treasuresCount, int levelsCount, int doesNotFightLevel) : base(level, name, treasuresCount, levelsCount, doesNotFightLevel)
    {
    }

    public override void Punish(Player.Player player)
    {
        player.LoseClass();
    }
}