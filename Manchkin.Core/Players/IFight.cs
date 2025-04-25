using Manchkin.Core.Cards.Doors;

namespace Manchkin.Core.Players;

public interface IFight
{
    Players.Player Player { get; }
    List<IMonster> Monsters { get; }
    int WashBonus { get; set; }
    int FightingStrengthBonus { get; }
    void AddMonster(IMonster monster);
    void AddFightingStrength(int strength);
}