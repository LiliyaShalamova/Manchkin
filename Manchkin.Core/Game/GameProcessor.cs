using Manchkin.Core.Cube;
using Manchkin.Core.Game.States;

namespace Manchkin.Core.Game;

internal class GameProcessor
{
    /// <summary>
    /// Текущее состояние игры
    /// </summary>
    public IState CurrentState { get; private set; }
    
    /// <summary>
    /// Кубик
    /// </summary>
    public ICube Cube { get; private set; }
    
    /// <summary>
    /// Текущий бой
    /// </summary>
    internal Fight? CurrentFight { get; set; }
    
    /// <summary>
    /// Индекс текущего игрока
    /// </summary>
    private int _currentPlayer;
    
    public Player.Player CurrentPlayer => Players[_currentPlayer];
    
    /// <summary>
    /// Массив игроков
    /// </summary>
    public Player.Player[] Players { get; }
    
    public GameProcessor(ICube cube, Player.Player[] players)
    {
        CurrentState = new StartState(this);
        Cube = cube;
        Players = players;
    }

    public void ChangeState(IState newState)
    {
        CurrentState = newState;
    }

    public void ChangeCurrentPlayer()
    {
        _currentPlayer = (_currentPlayer + 1) % Players.Length;
    }
}