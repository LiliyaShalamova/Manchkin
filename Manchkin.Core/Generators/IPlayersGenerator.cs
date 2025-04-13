using Manchkin.Core.Game;

namespace Manchkin.Core.Generators;

public interface IPlayersGenerator
{ 
    Players.Player[] Generate();
}