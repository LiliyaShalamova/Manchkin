using System.Collections.Immutable;
using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Game;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators;

internal class PlayersGenerator : IPlayersGenerator
{
    private readonly ICardsGenerator _cardsGenerator;
    private readonly int _playersCount;
    private readonly int _cardsNumberOfEachType;
    private readonly IRandomEnumValueGenerator _randomEnumValueGenerator;

    public PlayersGenerator(GameConfig cardsStorage, ICardsGenerator cardsGenerator,
        IRandomEnumValueGenerator randomEnumValueGenerator)
    {
        _cardsGenerator = cardsGenerator;
        _randomEnumValueGenerator = randomEnumValueGenerator;
        _playersCount = cardsStorage.PlayersCount;
        _cardsNumberOfEachType = cardsStorage.CardsNumberOfEachType;
    }
    
    public Player[] Generate()
    {
        var players = new Player[_playersCount];
        var colors = new Color[_playersCount];
        
        for (var i = 0; i < _playersCount; i++)
        {
            var color = _randomEnumValueGenerator.GenerateExcept(colors.ToArray());
            colors[i] = color;
            players[i] = CreatePlayer(color);
        }
        
        return players;
    }
    
    private Player CreatePlayer(Color color)
    {
        var cards = ImmutableList<ICard>.Empty;
        for (var i = 0; i < _cardsNumberOfEachType; i++)
        {
            cards = cards.Add(_cardsGenerator.GetDoorCard());
            cards = cards.Add(_cardsGenerator.GetTreasureCard());
        }
        
        var sex = _randomEnumValueGenerator.Generate<Sex>();
        return new Player(sex, color, cards);
    }
}