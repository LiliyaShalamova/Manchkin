using Manchkin.Core.Cube;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;

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
    public Fight? CurrentFight { get; set; }
    
    /// <summary>
    /// Хранилище карт
    /// </summary>
    public readonly CardsStorage CardsStorage;
    
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
    
    public GameProcessor(ICube cube, Players.Player[] players, CardsStorage cardsStorage, ICardsGenerator cardsGenerator)
    {
        CurrentState = new FinishState(this);
        Cube = cube;
        Players = players;
        CardsStorage = cardsStorage;
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