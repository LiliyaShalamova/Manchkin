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

    public new void Curse(Player from, Player to, ICurse curse)
    {
        base.Curse(from, to, curse);
    }

    public bool Cast(Player player, Spell spell)
    {
        return CastSpell(player, spell);
    }

    public bool Monster(Player player, Monster monster)
    {
        return false;
    }

    public Door Door(Player player)
    {
        var door = PullDoor();
        switch (door)
        {
            case Monster monster:
                _gameProcessor.ChangeState(new FightState(_gameProcessor));
                break;
            case Core.Curse:
                Curse(player, player, (ICurse)door);
                _gameProcessor.ChangeState(new SecondMoveState(_gameProcessor));
                break;
        }

        return door;
    }

    public bool GetAway(Player player)
    {
        return false;
    }

    public List<Command> GetAllowCommands()
    {
        return [Command.PutOn, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door];
    }

    public void Finish(Player player)
    {
    }

    private Door PullDoor()
    {
        var door = DoorGenerator.GetCard();
        return door;
    }

    private bool Fight(Player player, Monster monster)
    {
        CurrentFight = new Fight(player, monster);
        var playerWin = player.FightingStrength + CurrentFight.FightingStrengthBonus > monster.Level;

        return playerWin;
    }
}