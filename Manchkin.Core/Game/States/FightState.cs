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
        if (spell is OtherSpell)
        {
            return false;
        }
        var fightingSpell = (IFightingSpell)spell;
        return CastFightingSpell(player, fightingSpell);
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
        var washed = value >= _gameProcessor.CurrentFight!.WashBonus;
        if (washed)
        {
            GetReward(player);
            _gameProcessor.CurrentFight = null;
        }
        else
        {
            GetPunished();
        }
        _gameProcessor.ChangeState(new FirstMoveState(_gameProcessor));
        return washed;
    }

    public List<Command> GetAllowCommands()
    {
        return [Command.Cast, Command.GetAway, Command.Fight];
    }

    private void GetPunished()
    {
        foreach (var monster in _gameProcessor.CurrentFight!.Monsters)
        {
            ((IPunish)monster).Punish(_gameProcessor.CurrentFight.Player);
        }
        _gameProcessor.CurrentFight = null;
    }
    
    private void GetReward(Player player)
    {
        var monster = _gameProcessor.CurrentFight!.Monsters[0];
        for (var i = 0; i < monster.TreasuresCount; i++)
        {
            player.Cards.Add(TreasureGenerator.GetCard());
        }
        player.IncreaseLevel(monster.LevelsCount);
    }
    
    public void Finish(Player player)
    {
        
    }
    
    public bool Fight(Player player)
    {
        // TODO добавить обработку уровня с которого монстр начинает сражаться с игроком
        var playerWin = player.FightingStrength + _gameProcessor.CurrentFight!.FightingStrengthBonus > _gameProcessor.CurrentFight.Monsters.Sum(monster => monster.Level);
        if (playerWin)
        {
            GetReward(player);
            _gameProcessor.CurrentFight = null;
            _gameProcessor.ChangeState(new FirstMoveState(_gameProcessor));
        }
        
        Reset(player, _gameProcessor.CurrentFight!.Monsters.ToArray());
        return playerWin;
    }
    
    private bool CastFightingSpell(Player player, IFightingSpell fightingSpell)
    {
        fightingSpell.Cast(_gameProcessor.CurrentFight!);
        Reset(player, [(Card)fightingSpell]);
        return true;
    }
}