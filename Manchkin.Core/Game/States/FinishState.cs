using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Состояние игры, когда доступны только основные команды без дверей
/// </summary>
internal class FinishState(GameProcessor game) : GameStateBase(game) // TODO назвать FinishState DONE
{
    private readonly List<Command> _allowedCommands = [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Finish];

    public override CommandResult Dress(Clothes[] clothes)
    {
        FillInventory(GameProcessor.CurrentPlayer, clothes);
        return new CommandResult(true);
    }
    
    public override CommandResult Drop(Card[] cards)
    {
        ResetCards(GameProcessor.CurrentPlayer, cards);
        return new CommandResult(true);
    }
    
    public override CommandResultWith<bool> Sell(Treasure[] treasures)
    {
        return new CommandResultWith<bool>(true, SellTreasures(GameProcessor.CurrentPlayer, treasures));
    }
    
    public override CommandResultWith<bool> Finish()
    {
        var lastPlayer = GameProcessor.CurrentPlayer == GameProcessor.Players.Last();
        if (!IsNextMoveAllowed(GameProcessor.CurrentPlayer))
        {
            return new CommandResultWith<bool>(true, false);
        }
        if (!lastPlayer)
        {
            GameProcessor.SwitchToNextPlayer();
            return new CommandResultWith<bool>(true, true);
        }
        GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        GameProcessor.SwitchToNextPlayer();
        return new CommandResultWith<bool>(true, true);
    }
    
    public override CommandResultWith<bool> Curse(Player.Player to, ICurse curse)
    {
        Curse(GameProcessor.CurrentPlayer, to, curse);
        return new CommandResultWith<bool>(true, true);
    }
    
    public override CommandResultWith<bool> Cast(IOtherSpell spell)
    {
        return new CommandResultWith<bool>(true, CastOtherSpell(GameProcessor.CurrentPlayer, spell));
    }
    
    public override List<Command> GetAllowCommands()
    {
        return _allowedCommands;
    }
}