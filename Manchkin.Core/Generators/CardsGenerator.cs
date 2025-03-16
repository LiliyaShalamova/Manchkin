using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators;

public class CardsGenerator<T>
{
    private readonly Random _random = new();
    private readonly CardsParser _cardsParser = new();
    private readonly string _currentDirectory = Directory.GetCurrentDirectory();
    private string _clothesPath = @"\Manchkin.Core\Cards\CardsFiles\Clothes.txt";
    private string _cursesPath = @"\Manchkin.Core\Cards\CardsFiles\Curses.txt";
    private string _spellsPath = @"\Manchkin.Core\Cards\CardsFiles\Spells.txt";
    private string _monstersPath = @"\Manchkin.Core\Cards\CardsFiles\Monsters.txt";
    private List<T> Deck { get; }

    public CardsGenerator()
    {
        Deck = [];
        GenerateDeck();
    }

    public IEnumerable<T> GetCard()
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
        var fullCursesPath = $"{_currentDirectory}{_cursesPath}";
        Deck.AddRange((IEnumerable<T>)_cardsParser.ParseByDelimiters<Curse>(fullCursesPath, ";", ["/*"]));
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
        var fullMonstersPath = $"{_currentDirectory}{_monstersPath}";
        Deck.AddRange((IEnumerable<T>)_cardsParser.ParseByDelimiters<Monster>(fullMonstersPath, ";", ["/*"]));
    }
    
    private void GenerateTreasures()
    {
        GenerateClothes();
        GenerateSpells();
    }

    private void GenerateClothes()
    {
        var fullClothesPath = $"{_currentDirectory}{_clothesPath}";
        Deck.AddRange((IEnumerable<T>)_cardsParser.ParseByDelimiters<Clothes>(fullClothesPath, ";", ["/*"]));
    }
    
    private void GenerateSpells()
    {
        var fullSpellsPath = $"{_currentDirectory}{_spellsPath}";
        Deck.AddRange((IEnumerable<T>)_cardsParser.ParseByDelimiters<Spell>(fullSpellsPath, ";", ["/*"]));
    }
}