namespace Manchkin.Core.Generators;

public class PlayersGenerator
{
    private readonly Random _random = new Random();
    private CardsGenerator<Door> _doorGenerator = new();
    private CardsGenerator<Treasure> _treasureGenerator = new();
    
    public PlayersGenerator()
    {
    }

    public Player[] Generate(int playersCount)
    {
        var players = new Player[playersCount];
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
    
    private Player CreatePlayer(Color color)
    {
        var cards = new List<Card>();
        foreach (var card in _doorGenerator.GetCard())
        {
            cards.Add(card);
            if (cards.Count == 4) break;
        }
        foreach (var card in _treasureGenerator.GetCard())
        {
            cards.Add(card);
            if (cards.Count == 8) break;
        }
        
        return new Player((Sex)_random.Next(0, 1), color, cards);
    }
}