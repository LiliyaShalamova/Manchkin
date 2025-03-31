namespace Manchkin.Core.Cards.Doors.Monsters;

public class ArmorLossMonster : Monster, IPunish
{
    internal ArmorLossMonster(int level, string name, int treasuresCount, int levelsCount, int doesNotFightLevel) : base(level, name, treasuresCount, levelsCount, doesNotFightLevel)
    {
    }

    public void Punish(Player.Player player)
    {
        player.Inventory.Torso = null;
    }
}