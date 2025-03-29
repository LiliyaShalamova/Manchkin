using Manchkin.Core.Cube;
using Manchkin.Core.Generators;

namespace Manchkin.Core;
//TODO сделать класс GameProcessor
/// <summary>
/// Класс игры
/// </summary>
public class Game
{
    public GameProcessor GameProcessor { get; set; }

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
}