using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cube;

namespace Manchkin.Core.Game.States;

/// <summary>
/// Состояние битвы
/// </summary>
internal class FightState(GameProcessor gameProcessor) : GameStateBase(gameProcessor), IState
{
    protected override List<Command> AllowedCommands { get; } = [Command.Cast, Command.Run, Command.Fight];

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
        var value = GameProcessor.Cube.Throw(); //TODO без аргументов DONE
        if (!Enum.IsDefined(typeof(CubeFace), value))
            throw new ArgumentOutOfRangeException("Значение грани куба должно быть от 1 до 6");
        var washed = (int)value >= GameProcessor.CurrentFight!.WashBonus;
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
    
    private void GetPunished()
    {
        foreach (var monster in GameProcessor.CurrentFight!.Monsters)
        {
            monster.Punish(GameProcessor.CurrentFight.Player);
        }
        GameProcessor.CurrentFight = null;
    }
    
    private void GetReward(Players.Player player)
    {
        var treasuresReward = GameProcessor.CurrentFight!.Monsters.Sum(monster => monster.TreasuresCount);
        var levelReward = GameProcessor.CurrentFight!.Monsters.Sum(monster => monster.LevelsCount);
        for (var i = 0; i < treasuresReward; i++)
        {
            player.Cards.Add(CardsGenerator.GetCard<ITreasure>());
        }
        player.IncreaseLevel(levelReward);
    }
    
    private bool CastFightingSpell(Players.Player player, IFightingSpell fightingSpell)
    {
        fightingSpell.Cast(GameProcessor.CurrentFight!);
        Reset(player, [(ICard)fightingSpell]);
        return true;
    }
}