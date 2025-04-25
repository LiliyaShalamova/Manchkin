using Manchkin.Core.Cube;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;
using Manchkin.Core.Players;

namespace Manchkin.Core.Game;

internal interface IGameProcessor
{
    IState CurrentState { get; }
    Players.Player CurrentPlayer { get; }
    ICardsGenerator CardsGenerator { get; }
    Players.Player[] Players { get; }
    IFight? CurrentFight { get; set; }
    ICube Cube { get; }
    
    void ChangeState(IState newState)
    {
    }

    void SwitchToNextPlayer()
    {
    }
}