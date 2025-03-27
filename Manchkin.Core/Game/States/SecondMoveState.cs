using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core;

public class SecondMoveState : GameState, IState
{
    private GameProcessor _gameProcessor;
    public SecondMoveState(GameProcessor gameProcessor)
    {
        _gameProcessor = gameProcessor;
    }
    
    public Door PullDoor()
    {
        var door = DoorGenerator.GetCard();
        return door;
    }

    public void PutOn(Player player, Clothes[] clothes)
    {
        FillInventory(player, clothes);
    }

    public void Drop(Player player, Card[] cards)
    {
        ResetCards(player, cards);
    }

    public bool Sell(Player player, Treasure[] treasures)
    {
        return SellTreasures(player, treasures);
    }

    public bool Next(Player player, bool lastPlayer)
    {
        return false;
    }

    public void Curse(Player from, Player to, ICurse curse)
    {
        base.Curse(from, to, curse);
    }

    public bool Cast(Player player, Spell spell)
    {
        return CastSpell(player, spell);
    }

    public bool Monster(Player player, Monster monster)
    {
        _gameProcessor.ChangeState(new FightState(_gameProcessor));
        throw new NotImplementedException();
    }

    public Door Door(Player player)
    {
        var door = PullDoor();
        player.Cards.Add(door);
        _gameProcessor.ChangeState(new FirstMoveState(_gameProcessor));
        return door;
    }

    public bool GetAway(Player player)
    {
        return false;
    }

    public void Finish(Player player)
    {
        
    }

    public List<Command> GetAllowCommands()
    {
        return [Command.PutOn, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door, Command.Monster];
    }
}