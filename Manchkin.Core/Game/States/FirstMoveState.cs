using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Players;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Состояние первого хода игрока. Необходимо выбить дверь
/// </summary>
internal class FirstMoveState : GameStateBase, IState
{
    internal FirstMoveState(GameProcessor gameProcessor) : base(gameProcessor)
    {
        var currentPlayer = gameProcessor.CurrentPlayer;
        if (currentPlayer.IsDead)
        {
            DealCards(currentPlayer);
        }

        currentPlayer.IsDead = false;
    }
    protected override List<Command> AllowedCommands { get; } =
        [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door];

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
    
    public override CommandResultWith<IDoor> PullDoor()
    {
        var door = CardsGenerator.GetDoorCard();
        switch (door)
        {
            case IMonster monster:
                GameProcessor.ChangeState(new FightState(GameProcessor));
                GameProcessor.CurrentFight = new Fight(GameProcessor.CurrentPlayer, monster);
                break;
            case ICurse curse:
                Curse(GameProcessor.CurrentPlayer, GameProcessor.CurrentPlayer, curse);
                GameProcessor.ChangeState(new SecondMoveState(GameProcessor));
                break;
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

    private void DealCards(Player player)
    {
        for (var i = 0; i < 4; i++) // протянут сюда вместо константы 4 _cardsNumberOfEachType
        {
            player.Cards = player.Cards.Add(GameProcessor.CardsGenerator.GetDoorCard());
            player.Cards = player.Cards.Add(GameProcessor.CardsGenerator.GetTreasureCard());
        }
    }
}