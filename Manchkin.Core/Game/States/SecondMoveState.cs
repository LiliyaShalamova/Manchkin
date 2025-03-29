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
    
    public void PutOn(Clothes[] clothes)
    {
        FillInventory(_gameProcessor.CurrentPlayer, clothes);
    }

    public void Drop(Card[] cards)
    {
        ResetCards(_gameProcessor.CurrentPlayer, cards);
    }

    public bool Sell(Treasure[] treasures)
    {
        return SellTreasures(_gameProcessor.CurrentPlayer, treasures);
    }

    public bool Next()
    {
        return false;
    }

    public void Curse(Player to, ICurse curse)
    {
        base.Curse(_gameProcessor.CurrentPlayer, to, curse);
    }

    public bool Cast(Spell spell)
    {
        if (spell is FightingSpell)
        {
            return false;
        }
        var otherSpell = (IOtherSpell)spell;
        return CastOtherSpell(_gameProcessor.CurrentPlayer, otherSpell);
    }

    public bool Monster(Monster monster)
    {
        _gameProcessor.ChangeState(new FightState(_gameProcessor));
        _gameProcessor.CurrentFight = new Fight(_gameProcessor.CurrentPlayer, monster);
        return true;
    }

    public Door Door()
    {
        var door = PullDoor();
        _gameProcessor.CurrentPlayer.Cards.Add(door);
        _gameProcessor.ChangeCurrentPlayer();
        _gameProcessor.ChangeState(new FirstMoveState(_gameProcessor));
        return door;
    }

    public bool GetAway()
    {
        return false;
    }

    public void Finish()
    {
        
    }

    public bool Fight()
    {
        return false;
    }

    public List<Command> GetAllowCommands()
    {
        return [Command.PutOn, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door, Command.Monster];
    }

    private Door PullDoor()
    {
        var door = DoorGenerator.GetCard();
        return door;
    }
}