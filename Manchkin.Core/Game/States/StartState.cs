using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core;

public class StartState : GameState, IState
{
    private readonly GameProcessor _gameProcessor;
    public StartState(GameProcessor game)
    {
        _gameProcessor = game;
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
        var lastPlayer = _gameProcessor.CurrentPlayer == _gameProcessor.Players.Last();
        if (!IsNextMoveAllowed(_gameProcessor.CurrentPlayer)) return false;
        if (!lastPlayer)
        {
            _gameProcessor.ChangeCurrentPlayer();
            return true;
        }
        _gameProcessor.ChangeState(new FirstMoveState(_gameProcessor));
        _gameProcessor.ChangeCurrentPlayer();
        return true;
    }

    public new void Curse(Player to, ICurse curse)
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

    public Door Door() // TODO возвращать результат операции (должен быть единый подход абсолютно во всех командах)
    {
        throw new NotImplementedException(); // TODO все недопустимые команды НЕ ПЕРЕОПРЕДЕЛЯТЬ!!!!!
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
        return [Command.PutOn, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Next];
    }
}