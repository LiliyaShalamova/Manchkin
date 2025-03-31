using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Curses;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators;

internal class CardsGenerator<T> : ICardsGenerator<T>
{
    private readonly Random _random = new();
    private readonly ICardParser<Clothes> _clothesParser = new ClothesParser();
    private readonly ICardParser<Spell> _spellParser = new SpellParser();
    private readonly ICardParser<Monster> _monsterParser = new MonsterParser();
    private readonly ICardParser<Curse> _curseParser = new CurseParser();
    private List<T> Deck { get; }

    public CardsGenerator()
    {
        Deck = [];
        GenerateDeck();
    }

    public T GetCard()
    {
        return GetGenerator().First();
    }

    private IEnumerable<T> GetGenerator()
    {
        while (true)
        {
            yield return Deck[_random.Next(0, Deck.Count)];
        }
    }

    private void GenerateDeck()
    {
        if (typeof(T) == typeof(Door))
        {
            GenerateDoors();
        }

        if (typeof(T) == typeof(Treasure))
        {
            GenerateTreasures();
        }
    }
    
    private void GenerateDoors()
    {
        GenerateCurses();
        GenerateRaces();
        GeneratePlayerClasses();
        GenerateMonsters();
    }

    private void GenerateCurses()
    {
        Deck.AddRange((IEnumerable<T>)_curseParser.Parse());
    }
    
    private void GenerateRaces()
    {
        //const string racesPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\Races.txt";
        //Deck.AddRange((IEnumerable<T>)_cardsParser.ParseByDelimiters<Race>(racesPath, ";", ["/*"]));
    }
    
    private void GeneratePlayerClasses()
    {
        //const string playerClassPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\PlayerClasses.txt";
        //Deck.AddRange((IEnumerable<T>)_cardsParser.ParseByDelimiters<PlayerClass>(playerClassPath, ";", ["/*"]));
    }
    
    private void GenerateMonsters()
    {
        Deck.AddRange((IEnumerable<T>)_monsterParser.Parse());
    }
    
    private void GenerateTreasures()
    {
        GenerateClothes();
        GenerateSpells();
    }

    private void GenerateClothes()
    {
        Deck.AddRange((IEnumerable<T>)_clothesParser.Parse());
    }
    
    private void GenerateSpells()
    {
        Deck.AddRange((IEnumerable<T>)_spellParser.Parse());
    }
}