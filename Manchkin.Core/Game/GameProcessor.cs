using Manchkin.Core.Cube;

namespace Manchkin.Core;

public class GameProcessor
{
    /// <summary>
    /// Текущее состояние игры
    /// </summary>
    public IState CurrentState { get; private set; }
    
    /// <summary>
    /// Кубик
    /// </summary>
    public ICube Cube { get; set; }
    
    /// <summary>
    /// Текущий бой
    /// </summary>
    internal Fight? CurrentFight { get; set; }
    
    /// <summary>
    /// Индекс текущего игрока
    /// </summary>
    private int _currentPlayer = 0;
    
    public Player CurrentPlayer => Players[_currentPlayer];
    
    /// <summary>
    /// Массив игроков
    /// </summary>
    public Player[] Players { get; init; }
    
    public GameProcessor(ICube cube, Player[] players)
    {
        CurrentState = new StartState(this);
        Cube = cube;
        Players = players;
    }

    internal void ChangeState(IState newState)
    {
        CurrentState = newState;
    }

    internal void ChangeCurrentPlayer()
    {
        _currentPlayer = (_currentPlayer + 1) % Players.Length;
    }
}