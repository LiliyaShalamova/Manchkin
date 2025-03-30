using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Состояние битвы
/// </summary>
internal class FightState : GameStateBase
{
    public FightState(GameProcessor gameProcessor) : base(gameProcessor)
    {
    }

    public override CommandResult<bool> Cast(Spell spell)//если заклинание на убийство монстра, пока состояние игры не меняется, надо выполнить fight
    {
        if (spell is OtherSpell)
        {
            return new CommandResult<bool>
            {
                IsAvailable = true,
                Result = false
            };
        }
        var fightingSpell = (IFightingSpell)spell;
        CastFightingSpell(GameProcessor.CurrentPlayer, fightingSpell);
        if (GameProcessor.CurrentFight!.Monsters.Count == 0)
        {
            GameProcessor.CurrentFight = null;
            GameProcessor.ChangeCurrentPlayer();
            GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        }
        return new CommandResult<bool>
        {
            IsAvailable = true,
            Result = true
        };
    }

    public override CommandResult<bool> GetAway()
    {
        var currentPlayer = GameProcessor.CurrentPlayer;
        var value = GameProcessor.Cube.Throw(1, 7);
        var washed = value >= GameProcessor.CurrentFight!.WashBonus;
        Reset(currentPlayer, GameProcessor.CurrentFight!.Monsters.ToArray());
        if (washed)
        {
            GetReward(currentPlayer);
            GameProcessor.CurrentFight = null;
        }
        else
        {
            GetPunished();
        }
        GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        return new CommandResult<bool>
        {
            IsAvailable = true,
            Result = washed
        };
    }
    
    public override CommandResult<bool> Fight()
    {
        var currentPlayer = GameProcessor.CurrentPlayer;
        // TODO добавить обработку уровня с которого монстр начинает сражаться с игроком
        var playerWin = currentPlayer.FightingStrength + GameProcessor.CurrentFight!.FightingStrengthBonus > GameProcessor.CurrentFight.Monsters.Sum(monster => monster.Level);
        if (playerWin)
        {
            GetReward(currentPlayer);
            Reset(currentPlayer, GameProcessor.CurrentFight!.Monsters.ToArray());
            GameProcessor.CurrentFight = null;
            GameProcessor.ChangeCurrentPlayer();
            GameProcessor.ChangeState(new FirstMoveState(GameProcessor));// TODO после победы карт стало больше, состояние игры - первый ход, получаем лишнюю доступную команду дверь
        }
        //Reset(player, _gameProcessor.CurrentFight!.Monsters.ToArray());
        return new CommandResult<bool>
        {
            IsAvailable = true,
            Result = playerWin
        };
    }
    
    public override List<Command> GetAllowCommands()
    {
        return [Command.Cast, Command.Run, Command.Fight];
    }
    
    private void GetPunished()
    {
        foreach (var monster in GameProcessor.CurrentFight!.Monsters)
        {
            ((IPunish)monster).Punish(GameProcessor.CurrentFight.Player);
        }
        GameProcessor.CurrentFight = null;
    }
    
    private void GetReward(Player player)
    {
        var monster = GameProcessor.CurrentFight!.Monsters[0];
        for (var i = 0; i < monster.TreasuresCount; i++)
        {
            player.Cards.Add(TreasureGenerator.GetCard());
        }
        player.IncreaseLevel(monster.LevelsCount);
    }
    
    private bool CastFightingSpell(Player player, IFightingSpell fightingSpell)
    {
        fightingSpell.Cast(GameProcessor.CurrentFight!);
        Reset(player, [(Card)fightingSpell]);
        return true;
    }
}