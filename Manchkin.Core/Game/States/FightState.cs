using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core;

public class FightState : GameState, IState
{
    private GameProcessor _gameProcessor;
    
    public FightState(GameProcessor gameProcessor)
    {
        _gameProcessor = gameProcessor;
    }
    
    public void PutOn(Player player, Clothes[] clothes)
    {
    }

    public void Drop(Player player, Card[] cards)
    {
    }

    public bool Sell(Player player, Treasure[] treasures)
    {
        return false;
    }

    public bool Next(Player player, bool lastPlayer)
    {
        return false;
    }

    public new void Curse(Player from, Player to, ICurse curse)
    {
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
        throw new NotImplementedException();
    }

    public bool GetAway(Player player)
    {
        var value = Cube.Throw();
        var washed = value >= CurrentFight!.WashBonus;
        if (washed)
        {
            GetReward(player);
            CurrentFight = null;
        }
        else
        {
            GetPunished();
        }
        return washed;
    }

    public List<Command> GetAllowCommands()
    {
        return [Command.Cast, Command.GetAway];
    }

    private void GetPunished()
    {
        foreach (var monster in CurrentFight!.Monsters)
        {
            ((IPunish)monster).Punish(CurrentFight.Player);
        }
        CurrentFight = null;
    }
    
    private void GetReward(Player player)
    {
        var monster = CurrentFight.Monsters[0];
        for (var i = 0; i < monster.TreasuresCount; i++)
        {
            player.Cards.Add(TreasureGenerator.GetCard());
        }
        player.IncreaseLevel(monster.LevelsCount);
    }
    
    public void Finish(Player player)
    {
        
    }
    
    public bool Fight(Player player, Monster monster)
    {
        // TODO добавить обработку уровня с которого монстр начинает сражаться с игроком
        CurrentFight = new Fight(player, monster);
        var playerWin = player.FightingStrength + CurrentFight.FightingStrengthBonus > monster.Level;
        if (playerWin)
        {
            CurrentFight = null;
            GetReward(player);
        }
        
        Reset(player, [monster]);
        return playerWin;
    }
    
    
}