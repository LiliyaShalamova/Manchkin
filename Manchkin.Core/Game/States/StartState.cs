using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Начальное состояние игры, когда доступны только основные команды без дверей
/// </summary>
internal class StartState : GameStateBase
{
    public StartState(GameProcessor game) : base(game)
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
    
    public override CommandResult<bool> Next()
    {
        var lastPlayer = GameProcessor.CurrentPlayer == GameProcessor.Players.Last();
        if (!IsNextMoveAllowed(GameProcessor.CurrentPlayer))
        {
            return new CommandResult<bool>
            {
                IsAvailable = true,
                Result = false
            };
        }
        if (!lastPlayer)
        {
            GameProcessor.ChangeCurrentPlayer();
            return new CommandResult<bool>
            {
                IsAvailable = true,
                Result = true
            };
        }
        GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        GameProcessor.ChangeCurrentPlayer();
        return new CommandResult<bool>
        {
            IsAvailable = true,
            Result = true
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
        return [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Finish];
    }
}