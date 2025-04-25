using Manchkin.Core.Cube;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;
using Manchkin.Core.Players;

namespace Manchkin.Core.Game;

internal class GameProcessor : IGameProcessor
{
    /// <summary>
    /// Текущее состояние игры
    /// </summary>
    public IState CurrentState { get; private set; }
    
    /// <summary>
    /// Кубик
    /// </summary>
    public ICube Cube { get; }
    
    /// <summary>
    /// Текущий бой
    /// </summary>
    public IFight? CurrentFight { get; set; }
    
    /// <summary>
    /// Текущий игрок
    /// </summary>
    public Players.Player CurrentPlayer => Players[_currentPlayer];
    
    /// <summary>
    /// Индекс текущего игрока
    /// </summary>
    private int _currentPlayer;
    
    /// <summary>
    /// Массив игроков
    /// </summary>
    public Players.Player[] Players { get; }
    
    public ICardsGenerator CardsGenerator { get; }
    
    public GameProcessor(ICube cube, Players.Player[] players, ICardsGenerator cardsGenerator)
    {
        CurrentState = new StartState(this);
        Cube = cube;
        Players = players;
        CardsGenerator = cardsGenerator;
    }

    public void ChangeState(IState newState)
    {
        CurrentState = newState;
    }

    public void SwitchToNextPlayer()
    {
        _currentPlayer = (_currentPlayer + 1) % Players.Length;
    }
}