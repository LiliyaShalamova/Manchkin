using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Players;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Второй ход игрока, когда необходимо либо выбить вторую дверь, либо сразиться с монстром с руки
/// </summary>
internal class SecondMoveState(GameProcessor gameProcessor) : GameStateBase(gameProcessor), IState
{
    protected override List<Command> AllowedCommands { get; } = [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door, Command.Monster];

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
    
    public override CommandResultWith<bool> Monster(IMonster monster)
    {
        GameProcessor.CurrentPlayer.Cards = GameProcessor.CurrentPlayer.Cards.Remove(monster);
        GameProcessor.ChangeState(new FightState(GameProcessor));
        GameProcessor.CurrentFight = new Fight(GameProcessor.CurrentPlayer, monster);
        return new CommandResultWith<bool>(true, true);
    }

    public override CommandResultWith<IDoor> PullDoor()
    {
        var door = CardsGenerator.GetDoorCard();
        GameProcessor.CurrentPlayer.Cards = GameProcessor.CurrentPlayer.Cards.Add(door);
        if (!IsNextMoveAllowed(GameProcessor.CurrentPlayer))
        {
            GameProcessor.ChangeState(new FinishState(GameProcessor));
        }
        else
        {
            GameProcessor.SwitchToNextPlayer();
            GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        }
        return new CommandResultWith<IDoor>(true, door);
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