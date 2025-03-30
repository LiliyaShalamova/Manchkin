using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Game.States;

public interface IState
{
    public CommandResult<Void> PutOn(Clothes[] clothes);
    public CommandResult<Void> Drop(Card[] cards);
    public CommandResult<bool> Sell(Treasure[] treasures);
    public CommandResult<bool> Next();
    public CommandResult<bool> Curse(Player to, ICurse curse);
    public CommandResult<bool> Cast(Spell spell);
    public CommandResult<bool> Monster(Monster monster);
    public CommandResult<Door> Door();
    public CommandResult<bool> GetAway();
    public List<Command> GetAllowCommands();
    public CommandResult<bool> Fight();
}