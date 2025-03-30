using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cube;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;
using Void = Manchkin.Core.Game.States.Void;

namespace Manchkin.Core.Game;
//TODO сделать класс GameProcessor
/// <summary>
/// Класс игры
/// </summary>
public class Game
{
    private GameProcessor GameProcessor { get; set; }

    /// <summary>
    /// Количество уровней в игре
    /// </summary>
    private int _levelsCount = 10;

    /// <summary>
    /// Массив игроков
    /// </summary>
    public Player[] Players { get; }

    public Game(GameConfig gameConfig, IPlayersGenerator playersGenerator, ICube cube)
    {
        Players = playersGenerator.Generate(gameConfig.PlayersCount);
        GameProcessor = new GameProcessor(cube, Players);
    }

    public Game(GameConfig gameConfig, ICube cube)
    {
        Players = new PlayersGenerator().Generate(gameConfig.PlayersCount);
        GameProcessor = new GameProcessor(cube, Players);
    }

    public bool IsGameOver()
    {
        return Players.Max(player => player.Level) == _levelsCount;
    }

    public Player GetCurrentPlayer()
    {
        return GameProcessor.CurrentPlayer;
    }

    public CommandResult<Void> Dress(Clothes[] clothes)
    {
        return GameProcessor.CurrentState.Dress(clothes);
    }

    public CommandResult<Void> Drop(Card[] cards)
    {
        return GameProcessor.CurrentState.Drop(cards);
    }

    public CommandResult<bool> Sell(Treasure[] treasures)
    {
        return GameProcessor.CurrentState.Sell(treasures);
    }

    public CommandResult<bool> Curse(Player to, ICurse curse)
    {
        return GameProcessor.CurrentState.Curse(to, curse);
    }

    public CommandResult<bool> Finish()
    {
        return GameProcessor.CurrentState.Finish();
    }

    public CommandResult<bool> Cast(Spell spell)
    {
        return GameProcessor.CurrentState.Cast(spell);
    }

    public CommandResult<bool> Monster(Monster monster)
    {
        return GameProcessor.CurrentState.Monster(monster);
    }

    public CommandResult<Door> Door()
    {
        return GameProcessor.CurrentState.Door();
    }

    public CommandResult<bool> Run()
    {
        return GameProcessor.CurrentState.Run();
    }

    public List<Command> GetAllowCommands()
    {
        return GameProcessor.CurrentState.GetAllowCommands();
    }

    public CommandResult<bool> Fight()
    {
        return GameProcessor.CurrentState.Fight();
    }
}