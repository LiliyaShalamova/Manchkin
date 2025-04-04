using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Второй ход игрока, когда необходимо либо выбить вторую дверь, либо сразиться с монстром с руки
/// </summary>
internal class SecondMoveState(GameProcessor gameProcessor) : GameStateBase(gameProcessor)
{
    private readonly List<Command> _allowedCommands = [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door, Command.Monster];

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
    
    public override CommandResultWith<bool> Monster(Monster monster)
    {
        GameProcessor.ChangeState(new FightState(GameProcessor));
        GameProcessor.CurrentFight = new Fight(GameProcessor.CurrentPlayer, monster);
        return new CommandResultWith<bool>(true, true);
    }

    public override CommandResultWith<Door> PullDoor()
    {
        var door = DoorGenerator.GetCard();
        GameProcessor.CurrentPlayer.Cards.Add(door);
        GameProcessor.SwitchToNextPlayer();
        GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        return new CommandResultWith<Door>(true, door);
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