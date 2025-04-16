using Manchkin.Core.Game;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators;

public interface IPlayersGenerator
{ 
    Players.Player[] Generate();
}