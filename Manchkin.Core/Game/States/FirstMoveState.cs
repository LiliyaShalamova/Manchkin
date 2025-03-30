using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Состояние первого хода игрока. Необходимо выбить дверь
/// </summary>
internal class FirstMoveState : GameStateBase
{
    private readonly List<Command> _allowedCommands = [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door];
    public FirstMoveState(GameProcessor gameProcessor) : base(gameProcessor)
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
    
    public override CommandResult<Door> Door()
    {
        var door = PullDoor();
        switch (door)
        {
            case Monster monster:
                GameProcessor.ChangeState(new FightState(GameProcessor));
                GameProcessor.CurrentFight = new Fight(GameProcessor.CurrentPlayer, monster);
                break;
            case Core.Curse:
                Curse(GameProcessor.CurrentPlayer, GameProcessor.CurrentPlayer, (ICurse)door);
                GameProcessor.ChangeState(new SecondMoveState(GameProcessor));
                break;
        }

        return new CommandResult<Door>(true, door);
    }

    public override CommandResult<bool> Curse(Player to, ICurse curse)
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
        return _allowedCommands; // TODO каждый раз при вызове создается массив, переделать. DONE
    }

    private Door PullDoor()
    {
        var door = DoorGenerator.GetCard();
        return door;
    }
}