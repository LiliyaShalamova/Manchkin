using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Game;
using Manchkin.Core.Player;

namespace Manchkin.Core.Generators;

internal class PlayersGenerator : IPlayersGenerator
{
    private readonly IRandom _random; // TODO везде использование random вынести в отдельный класс с интерфейсом DONE
    private readonly ICardsGenerator _cardsGenerator; //было два, теперь один + передаю из game
    private readonly int _playersCount;
    private readonly int _cardsNumberOfEachType;
    private readonly IRandomEnumValueGenerator _randomEnumValueGenerator;

    public PlayersGenerator(IRandom randomNumber, GameConfig gameConfig, ICardsGenerator cardsGenerator,
        IRandomEnumValueGenerator randomEnumValueGenerator) // TODO получать конфиг DONE
    {
        _random = randomNumber;
        _cardsGenerator = cardsGenerator;
        _randomEnumValueGenerator = randomEnumValueGenerator;
        _playersCount = gameConfig.PlayersCount;
        _cardsNumberOfEachType = gameConfig.CardsNumberOfEachType;
    }
    
    public Players.Player[] Generate()
    {
        var players = new Players.Player[_playersCount];
        var colors = new List<Color>();
        
        for (var i = 0; i < _playersCount; i++) // TODO сделать без HashSet и цикла while DONE
        {
            var color = _randomEnumValueGenerator.GetRandomValueExcept(colors);
            colors.Add(color);
            players[i] = CreatePlayer(color);
        }
        
        return players;
    }
    
    private Players.Player CreatePlayer(Color color)
    {
        var cards = new List<ICard>();
        for (var i = 0; i < _cardsNumberOfEachType; i++)
        {
            cards.Add(_cardsGenerator.GetCard<IDoor>());
            cards.Add(_cardsGenerator.GetCard<ITreasure>());
        }
        
        var sex = _randomEnumValueGenerator.GetRandomValueByEnumType<Sex>(); // TODO сделать отдельный класс, который по типу енама возвращает рандомное значение DONE
        return new Players.Player(sex, color, cards);
    }
}