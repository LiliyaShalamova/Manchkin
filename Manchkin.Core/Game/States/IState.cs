using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Core.Game.States;

internal interface IState
{
    public CommandResult Dress(Clothes[] clothes);
    public CommandResult Drop(Card[] cards);
    public CommandResultWith<bool> Sell(Treasure[] treasures);
    public CommandResultWith<bool> Finish();
    public CommandResultWith<bool> Curse(Player.Player to, ICurse curse);
    public CommandResultWith<bool> Cast(IFightingSpell spell);
    public CommandResultWith<bool> Cast(IOtherSpell spell);
    public CommandResultWith<bool> Monster(Monster monster);
    public CommandResultWith<Door> PullDoor();
    public CommandResultWith<bool> Run();
    public List<Command> GetAllowCommands();
    public CommandResultWith<bool> Fight();
}