using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Players;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Состояние игры, когда доступны только основные команды без дверей
/// </summary>
internal class StartState(IGameProcessor game) : GameStateBase(game), IState
{
    protected override List<Command> AllowedCommands { get; } = [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Finish];

    public override CommandResult Dress(IClothes[] clothes)
    {
        FillInventory(GameProcessor.CurrentPlayer, clothes);
        return new CommandResult(true);
    }
    
    public override CommandResult Drop(ICard[] cards)
    {
        ResetCards(GameProcessor.CurrentPlayer, cards);
        return new CommandResult(true);
    }
    
    public override CommandResultWith<bool> Sell(ITreasure[] treasures)
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
        if (!lastPlayer)//это состояние не подходит для сброса карт на второй фазе, т.к. если игрок не последний состояние все равно должно меняться DONE - есть startstate и finishstate
        {
            GameProcessor.SwitchToNextPlayer();
            return new CommandResultWith<bool>(true, true);
        }
        GameProcessor.ChangeState(new FirstMoveState(GameProcessor)); // сделать через дженерик
        GameProcessor.SwitchToNextPlayer();
        return new CommandResultWith<bool>(true, true);
    }
    
    public override CommandResultWith<bool> Curse(Player to, ICurse curse)
    {
        Curse(GameProcessor.CurrentPlayer, to, curse);
        return new CommandResultWith<bool>(true, true);
    }
    
    public override CommandResultWith<bool> Cast(IOtherSpell spell)
    {
        return new CommandResultWith<bool>(true, CastOtherSpell(GameProcessor.CurrentPlayer, spell));
    }
}