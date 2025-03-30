using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Состояние первого хода игрока. Необходимо выбить дверь
/// </summary>
internal class FirstMoveState : GameStateBase
{
    public FirstMoveState(GameProcessor gameProcessor) : base(gameProcessor)
    {
    }
    
    public override CommandResult<Void> PutOn(Clothes[] clothes)
    {
        FillInventory(GameProcessor.CurrentPlayer, clothes);
        return new CommandResult<Void>
        {
            IsAvailable = true,
            Result = new Void()
        };
    }
    
    public override CommandResult<Void> Drop(Card[] cards)
    {
        ResetCards(GameProcessor.CurrentPlayer, cards);
        return new CommandResult<Void>
        {
            IsAvailable = true,
            Result = new Void()
        };
    }
    
    public override CommandResult<bool> Sell(Treasure[] treasures)
    {
        return new CommandResult<bool>
        {
            IsAvailable = true,
            Result = SellTreasures(GameProcessor.CurrentPlayer, treasures)
        };
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

        return new CommandResult<Door>
        {
            IsAvailable = true,
            Result = door
        };
    }

    public override CommandResult<bool> Curse(Player to, ICurse curse)
    {
        Curse(GameProcessor.CurrentPlayer, to, curse);
        return new CommandResult<bool>
        {
            IsAvailable = true,
            Result = true
        };
    }
    
    public override CommandResult<bool> Cast(Spell spell)
    {
        if (spell is FightingSpell)
        {
            return new CommandResult<bool>
            {
                IsAvailable = true,
                Result = false
            };
        }
        var otherSpell = (IOtherSpell)spell;
        return new CommandResult<bool>
        {
            IsAvailable = true,
            Result = CastOtherSpell(GameProcessor.CurrentPlayer, otherSpell)
        };
    }
    
    public override List<Command> GetAllowCommands()
    {
        return [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door]; // TODO каждый раз при вызове создается массив, переделать.
    }

    private Door PullDoor()
    {
        var door = DoorGenerator.GetCard();
        return door;
    }
}