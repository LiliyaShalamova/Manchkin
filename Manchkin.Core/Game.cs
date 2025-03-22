using Manchkin.Core.Generators;

namespace Manchkin.Core;
//TODO сделать класс GameProcessor
/// <summary>
/// Класс игры
/// </summary>
public class Game
{
    public GameProcessor GameProcessor { get; set; } = new();

    /// <summary>
    /// Количество уровней в игре
    /// </summary>
    public int LevelsCount => 10;

    /// <summary>
    /// Массив игроков
    /// </summary>
    public Player[] Players { get; init; }

    public Game(GameConfig gameConfig, IPlayersGenerator playersGenerator)
    {
        Players = playersGenerator.Generate(gameConfig.PlayersCount);
    }

    public Game(GameConfig gameConfig)
    {
        Players = new PlayersGenerator().Generate(gameConfig.PlayersCount);
    }
    
    /*
     * TODO
     * Оставить в Core как можно меньше кастов. Вынести всё в консоль по возможности
     */
}