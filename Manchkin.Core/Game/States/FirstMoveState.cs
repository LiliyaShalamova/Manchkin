using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Состояние первого хода игрока. Необходимо выбить дверь
/// </summary>
internal class FirstMoveState(GameProcessor gameProcessor) : GameStateBase(gameProcessor)
{
    private readonly List<Command> _allowedCommands = [Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door];

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
    
    public override CommandResultWith<Door> PullDoor()
    {
        var door = DoorGenerator.GetCard();
        switch (door)
        {
            case Monster monster:
                GameProcessor.ChangeState(new FightState(GameProcessor));
                GameProcessor.CurrentFight = new Fight(GameProcessor.CurrentPlayer, monster);
                break;
            case Cards.Doors.Curses.Curse:
                Curse(GameProcessor.CurrentPlayer, GameProcessor.CurrentPlayer, (ICurse)door);
                GameProcessor.ChangeState(new SecondMoveState(GameProcessor));
                break;
        }

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
        return _allowedCommands; // TODO каждый раз при вызове создается массив, переделать. DONE
    }
}