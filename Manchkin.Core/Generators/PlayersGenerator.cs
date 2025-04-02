using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Player;

namespace Manchkin.Core.Generators;

internal class PlayersGenerator : IPlayersGenerator
{
    private readonly Random _random = new();
    private CardsGenerator<Door> _doorGenerator = new();
    private CardsGenerator<Treasure> _treasureGenerator = new();

    public Player.Player[] Generate(int playersCount)
    {
        var players = new Player.Player[playersCount];
        var colors = new HashSet<Color>();
        while (colors.Count < playersCount)
        {
            colors.Add((Color)_random.Next(0, 6));
        }
        
        for (var i = 0; i < playersCount; i++)
        {
            players[i] = CreatePlayer(colors.ElementAt(i));
        }
        
        return players;
    }
    
    private Player.Player CreatePlayer(Color color)
    {
        var cards = new List<Card>();
        for (var i = 0; i < 4; i++)
        {
            cards.Add(_doorGenerator.GetCard());
            cards.Add(_treasureGenerator.GetCard());
        }
        
        return new Player.Player((Sex)_random.Next(0, 1), color, cards);
    }
}