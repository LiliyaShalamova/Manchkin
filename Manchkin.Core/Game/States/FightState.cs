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
    
    public void PutOn(Clothes[] clothes)
    {
    }

    public void Drop(Card[] cards)
    {
    }

    public bool Sell(Treasure[] treasures)
    {
        return false;
    }

    public bool Next()
    {
        return false;
    }

    public new void Curse(Player to, ICurse curse)
    {
    }

    public bool Cast(Spell spell)//если заклинание на убийство монстра, пока состояние игры не меняется, надо выполнить fight
    {
        if (spell is OtherSpell)
        {
            return false;
        }
        var fightingSpell = (IFightingSpell)spell;
        CastFightingSpell(_gameProcessor.CurrentPlayer, fightingSpell);
        if (_gameProcessor.CurrentFight!.Monsters.Count == 0)
        {
            _gameProcessor.CurrentFight = null;
            _gameProcessor.ChangeCurrentPlayer();
            _gameProcessor.ChangeState(new FirstMoveState(_gameProcessor));
        }
        return true;
    }

    public bool Monster(Monster monster)
    {
        return false;
    }

    public Door Door()
    {
        throw new NotImplementedException();
    }

    public bool GetAway()
    {
        var currentPlayer = _gameProcessor.CurrentPlayer;
        var value = _gameProcessor.Cube.Throw(1, 7);
        var washed = value >= _gameProcessor.CurrentFight!.WashBonus;
        Reset(currentPlayer, _gameProcessor.CurrentFight!.Monsters.ToArray());
        if (washed)
        {
            GetReward(currentPlayer);
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
    
    public void Finish()
    {
        
    }
    
    public bool Fight()
    {
        var currentPlayer = _gameProcessor.CurrentPlayer;
        // TODO добавить обработку уровня с которого монстр начинает сражаться с игроком
        var playerWin = currentPlayer.FightingStrength + _gameProcessor.CurrentFight!.FightingStrengthBonus > _gameProcessor.CurrentFight.Monsters.Sum(monster => monster.Level);
        if (playerWin)
        {
            GetReward(currentPlayer);
            Reset(currentPlayer, _gameProcessor.CurrentFight!.Monsters.ToArray());
            _gameProcessor.CurrentFight = null;
            _gameProcessor.ChangeCurrentPlayer();
            _gameProcessor.ChangeState(new FirstMoveState(_gameProcessor));// TODO после победы карт стало больше, состояние игры - первый ход, получаем лишнюю доступную команду дверь
        }
        
        //Reset(player, _gameProcessor.CurrentFight!.Monsters.ToArray());
        return playerWin;
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
    
    private bool CastFightingSpell(Player player, IFightingSpell fightingSpell)
    {
        fightingSpell.Cast(_gameProcessor.CurrentFight!);
        Reset(player, [(Card)fightingSpell]);
        return true;
    }
}