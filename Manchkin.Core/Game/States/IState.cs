using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Game.States;

internal interface IState
{
    public CommandResult<Void> Dress(Clothes[] clothes);
    public CommandResult<Void> Drop(Card[] cards);
    public CommandResult<bool> Sell(Treasure[] treasures);
    public CommandResult<bool> Finish();
    public CommandResult<bool> Curse(Player.Player to, ICurse curse);
    public CommandResult<bool> Cast(Spell spell);
    public CommandResult<bool> Monster(Monster monster);
    public CommandResult<Door> Door();
    public CommandResult<bool> Run();
    public List<Command> GetAllowCommands();
    public CommandResult<bool> Fight();
}