using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Состояние битвы
/// </summary>
internal class FightState(GameProcessor gameProcessor) : GameStateBase(gameProcessor)
{
    private readonly List<Command> _allowedCommands = [Command.Cast, Command.Run, Command.Fight];

    public override CommandResultWith<bool> Cast(IFightingSpell spell)//если заклинание на убийство монстра, состояние игры не меняется, надо выполнить fight
    {
        CastFightingSpell(GameProcessor.CurrentPlayer, spell);
        /*if (GameProcessor.CurrentFight!.Monsters.Count == 0)
        {
            GameProcessor.CurrentFight = null;
            GameProcessor.SwitchToNextPlayer();
            GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        }*/
        return new CommandResultWith<bool>(true, true);
    }

    public override CommandResultWith<bool> Run()
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
        return new CommandResultWith<bool>(true, washed);
    }
    
    public override CommandResultWith<bool> Fight()
    {
        var currentPlayer = GameProcessor.CurrentPlayer;
        // TODO добавить обработку уровня с которого монстр начинает сражаться с игроком
        var playerFightingStrength = currentPlayer.FightingStrength + GameProcessor.CurrentFight!.FightingStrengthBonus;
        var monstersFightingStrength = GameProcessor.CurrentFight.Monsters.Count > 0 ? GameProcessor.CurrentFight.Monsters.Sum(monster => monster.Level) : 0;
        var playerWin = playerFightingStrength > monstersFightingStrength;
        Reset(currentPlayer, GameProcessor.CurrentFight!.Monsters.ToArray());
        if (playerWin)
        {
            GetReward(currentPlayer);
            GameProcessor.CurrentFight = null;
            if (!IsNextMoveAllowed(currentPlayer))
            {
                GameProcessor.ChangeState(new FinishState(GameProcessor));
            }
            else
            {
                GameProcessor.SwitchToNextPlayer();
                GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
            }
        }
        else
        {
            GetPunished();
            GameProcessor.SwitchToNextPlayer();
            GameProcessor.ChangeState(new FirstMoveState(GameProcessor));
        }
        return new CommandResultWith<bool>(true, playerWin);
    }
    
    public override List<Command> GetAllowCommands()
    {
        return _allowedCommands;
    }
    
    private void GetPunished()
    {
        foreach (var monster in GameProcessor.CurrentFight!.Monsters)
        {
            monster.Punish(GameProcessor.CurrentFight.Player);
        }
        GameProcessor.CurrentFight = null;
    }
    
    private void GetReward(Player.Player player)
    {
        var treasuresReward = GameProcessor.CurrentFight!.Monsters.Sum(monster => monster.TreasuresCount);
        var levelReward = GameProcessor.CurrentFight!.Monsters.Sum(monster => monster.LevelsCount);
        for (var i = 0; i < treasuresReward; i++)
        {
            player.Cards.Add(TreasureGenerator.GetCard());
        }
        player.IncreaseLevel(levelReward);
    }
    
    private bool CastFightingSpell(Player.Player player, IFightingSpell fightingSpell)
    {
        fightingSpell.Cast(GameProcessor.CurrentFight!);
        Reset(player, [(Card)fightingSpell]);
        return true;
    }
}