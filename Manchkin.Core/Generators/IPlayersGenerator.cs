namespace Manchkin.Core.Generators;

public interface IPlayersGenerator
{
    public Player.Player[] Generate(int playersCount);
}