using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Начальное состояние игры, когда доступны только основные команды без дверей
/// </summary>
internal class StartState : GameStateBase
{
    private readonly List<Command> _allowedCommands = [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Finish];
    public StartState(GameProcessor game) : base(game)
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
    
    public override CommandResult<bool> Finish()
    {
        var lastPlayer = GameProcessor.CurrentPlayer == GameProcessor.Players.Last();
        if (!IsNextMoveAllowed(GameProcessor.CurrentPlayer))
        {
            return new CommandResult<bool>(true, false);
        }
        if (!lastPlayer)
        {
            GameProcessor.ChangeCurrentPlayer();
            return new CommandResult<bool>(true, true);
        }
        GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        GameProcessor.ChangeCurrentPlayer();
        return new CommandResult<bool>(true, true);
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
        return _allowedCommands;
    }
}