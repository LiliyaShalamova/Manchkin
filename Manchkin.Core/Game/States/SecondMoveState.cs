using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Второй ход игрока, когда необходимо либо выбить вторую дверь, либо сразиться с монстром с руки
/// </summary>
internal class SecondMoveState : GameStateBase
{
    private List<Command> _allowedCommands = [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door, Command.Monster];
    public SecondMoveState(GameProcessor gameProcessor) : base(gameProcessor)
    {
    }

    public override CommandResult<Void> Dress(Clothes[] clothes)
    {
        FillInventory(GameProcessor.CurrentPlayer, clothes);
        return new CommandResult<Void>(true, new Void());
    }
    
    public override CommandResult<Void> Drop(Card[] cards)
    {
        ResetCards(GameProcessor.CurrentPlayer, cards);
        return new CommandResult<Void>(true, new Void());
    }
    
    public override CommandResult<bool> Sell(Treasure[] treasures)
    {
        return new CommandResult<bool>(true, SellTreasures(GameProcessor.CurrentPlayer, treasures));
    }
    
    public override CommandResult<bool> Monster(Monster monster)
    {
        GameProcessor.ChangeState(new FightState(GameProcessor));
        GameProcessor.CurrentFight = new Fight(GameProcessor.CurrentPlayer, monster);
        return new CommandResult<bool>(true, true);
    }

    public override CommandResult<Door> Door()
    {
        var door = PullDoor();
        GameProcessor.CurrentPlayer.Cards.Add(door);
        GameProcessor.ChangeCurrentPlayer();
        GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        return new CommandResult<Door>(true, door);
    }
    
    public override CommandResult<bool> Curse(Player.Player to, ICurse curse)
    {
        Curse(GameProcessor.CurrentPlayer, to, curse);
        return new CommandResult<bool>(true, true);
    }

    public override CommandResult<bool> Cast(Spell spell)
    {
        if (spell is FightingSpell)
        {
            return new CommandResult<bool>(true, false);
        }
        var otherSpell = (IOtherSpell)spell;
        return new CommandResult<bool>(true, CastOtherSpell(GameProcessor.CurrentPlayer, otherSpell));
    }
    
    public override List<Command> GetAllowCommands()
    {
        return _allowedCommands;
    }

    private Door PullDoor()
    {
        var door = DoorGenerator.GetCard();
        return door;
    }
}