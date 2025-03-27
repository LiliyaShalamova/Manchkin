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
        if (!IsNextMoveAllowed(player)) return false;
        if (!lastPlayer) return true;
        _gameProcessor.ChangeState(new FirstMoveState(_gameProcessor));
        return true;
    }

    public new void Curse(Player from, Player to, ICurse curse)
    {
        base.Curse(from, to, curse);
    }

    public bool Cast(Player player, Spell spell)
    {
        if (spell is FightingSpell)
        {
            return false;
        }
        var otherSpell = (IOtherSpell)spell;
        return CastOtherSpell(player, otherSpell);
    }

    public bool Monster(Player player, Monster monster)
    {
        return false;
    }

    public Door Door(Player player)
    {
        throw new NotImplementedException();
    }

    public bool GetAway(Player player)
    {
        return false;
    }

    public void Finish(Player player)
    {
        
    }

    public bool Fight(Player player)
    {
        return false;
    }

    public List<Command> GetAllowCommands()
    {
        return [Command.PutOn, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Next];
    }
}