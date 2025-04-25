using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Players;

namespace Manchkin.Core.Game.States;

internal class FinishState(IGameProcessor game) : GameStateBase(game), IState
{
    protected override List<Command> AllowedCommands { get; } =
        [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Finish];

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
        if (!IsNextMoveAllowed(GameProcessor.CurrentPlayer))
        {
            return new CommandResultWith<bool>(true, false);
        }

        GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
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