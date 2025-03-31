namespace Manchkin.Core.Cards.Doors.Monsters;

public class ShoesLossMonster : Monster, IPunish
{
    internal ShoesLossMonster(int level, string name, int treasuresCount, int levelsCount, int doesNotFightLevel) : base(level, name, treasuresCount, levelsCount, doesNotFightLevel)
    {
    }

    public void Punish(Player.Player player)
    {
        player.Inventory.Legs = null;
    }
}