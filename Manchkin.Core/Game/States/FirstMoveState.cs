using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core;

public class FirstMoveState : GameState, IState
{
    private GameProcessor _gameProcessor;

    public FirstMoveState(GameProcessor gameProcessor)
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
        return false;
    }

    public Door Door()
    {
        var door = PullDoor();
        switch (door)
        {
            case Monster monster:
                _gameProcessor.ChangeState(new FightState(_gameProcessor));
                _gameProcessor.CurrentFight = new Fight(_gameProcessor.CurrentPlayer, monster);
                break;
            case Core.Curse:
                Curse(_gameProcessor.CurrentPlayer, _gameProcessor.CurrentPlayer, (ICurse)door);
                _gameProcessor.ChangeState(new SecondMoveState(_gameProcessor));
                break;
        }

        return door;
    }

    public bool GetAway()
    {
        return false;
    }

    public List<Command> GetAllowCommands()
    {
        return [Command.PutOn, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door];
    }

    public void Finish()
    {
    }

    public bool Fight()
    {
        return false;
    }

    private Door PullDoor()
    {
        var door = DoorGenerator.GetCard();
        return door;
    }
/*
    public bool Fight(Player player, Monster monster)
    {
        return false;
    }*/
}