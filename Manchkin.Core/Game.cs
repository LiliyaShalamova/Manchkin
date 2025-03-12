using System.Text.Json.Serialization.Metadata;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Microsoft.VisualBasic.FileIO;

namespace Manchkin.Core;

/// <summary>
/// Класс игры
/// </summary>
public class Game
{
    private Random _random = new();
    private CardsParser _cardsParser = new();

    /// <summary>
    /// Количество уровней в игре
    /// </summary>
    public int LevelsCount => 10;

    /// <summary>
    /// Массив игроков
    /// </summary>
    private Player[] Players { get; set; }

    /// <summary>
    /// Массив дверей
    /// </summary>
    private List<Door> Doors { get; set; }

    /// <summary>
    /// Массив сокровищ
    /// </summary>
    private List<Treasure> Treasures { get; set; }

    /// <summary>
    /// Массив карт сброса дверей
    /// </summary>
    private List<Door> DoorsReset { get; set; }

    /// <summary>
    /// Массив карт сброса сокровищ
    /// </summary>
    private List<Treasure> TreasuresReset { get; set; }

    /// <summary>
    /// Текущий бой
    /// </summary>
    private Fight? CurrentFight { get; set; }

    public Game(int playersCount)
    {
        DoorsReset = [];
        TreasuresReset = [];
        GenerateDoors();
        GenerateTreasures();
        Players = new Player[playersCount];
        GeneratePlayers();
    }

    private void GenerateDoors()
    {
        Doors = [];
        GenerateCurses();
        GenerateRaces();
        GeneratePlayerClasses();
        GenerateMonsters();
        //Перемешать двери()
    }

    private void GenerateCurses()
    {
        const string clothesPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\Curses.txt";
        Doors.AddRange(_cardsParser.ParseByDelimiters<Curse>(clothesPath, ";", ["/*"]));
    }
    
    private void GenerateRaces()
    {
        const string clothesPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\Races.txt";
        Doors.AddRange(_cardsParser.ParseByDelimiters<Race>(clothesPath, ";", ["/*"]));
    }
    
    private void GeneratePlayerClasses()
    {
        const string clothesPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\PlayerClasses.txt";
        Doors.AddRange(_cardsParser.ParseByDelimiters<PlayerClass>(clothesPath, ";", ["/*"]));
    }
    
    private void GenerateMonsters()
    {
        const string clothesPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\Monsters.txt";
        Doors.AddRange(_cardsParser.ParseByDelimiters<Monster>(clothesPath, ";", ["/*"]));
    }

    private void GenerateTreasures()
    {
        Treasures = [];
        GenerateClothes();
        GenerateSpells();
        //Перемешать сокровища()
    }

    private void GenerateClothes()
    {
        const string clothesPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\Clothes.txt";
        Treasures.AddRange(_cardsParser.ParseByDelimiters<Clothes>(clothesPath, ";", ["/*"]));
    }
    
    private void GenerateSpells()
    {
        const string spellsPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\Spells.txt";
        Treasures.AddRange(_cardsParser.ParseByDelimiters<Spell>(spellsPath, ";", ["/*"]));
    }

    private void GeneratePlayers()
    {
        var playersCount = Players.Length;
        var colors = new HashSet<Color>();
        while (colors.Count < playersCount)
        {
            colors.Add((Color)_random.Next(0, 5));
        }
        
        for (var i = 0; i < playersCount; i++)
        {
            Players[i] = CreatePlayer(colors.ElementAt(i));
        }
    }

    private Player CreatePlayer(Color color)
    {
        //Взять по 4 карты из каждой колоды
        return new Player((Sex)_random.Next(0, 1), color);
    }
}