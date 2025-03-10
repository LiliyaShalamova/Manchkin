using System.Text.Json.Serialization.Metadata;
using Microsoft.VisualBasic.FileIO;

namespace Manchkin.Core;

/// <summary>
/// Класс игры
/// </summary>
public class Game
{
    private Random _random = new Random();

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
        Players = new Player[playersCount];
        GeneratePlayers();
        DoorsReset = [];
        TreasuresReset = [];
        GenerateDoors();
        GenerateTreasures();
    }

    private void GenerateDoors()
    {
    }

    private void GenerateTreasures()
    {
        Treasures = [];
        GenerateClothes();
        GenerateSpells();
    }

    private void GenerateClothes()
    {
        var clothesPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\Clothes.txt";
        using var parser = new TextFieldParser(clothesPath);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(";");
        parser.CommentTokens = ["/*"];
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            var clothesType = fields![0];
            var bonus = int.Parse(fields[1]);
            var price = int.Parse(fields[2]);
            var title = fields[3];
            var isBig = Convert.ToBoolean(int.Parse(fields[4]));
            var wash = int.Parse(fields[5]);
            switch (clothesType)
            {
                case "Additional":
                    Treasures.Add(new Clothes(bonus, price, title, isBig, wash));
                    break;
                case "Weapon":
                    var handsAmount = int.Parse(fields[6]);
                    Treasures.Add(new Weapon(bonus, price, title, isBig, wash, handsAmount));
                    break;
                case "Shoes":
                    Treasures.Add(new Shoes(bonus, price, title, isBig, wash));
                    break;
                case "BulletproofVest":
                    Treasures.Add(new BulletproofVest(bonus, price, title, isBig, wash));
                    break;
                case "Smut":
                    Treasures.Add(new Smut(bonus, price, title, isBig, wash));
                    break;
            }
        }
    }
    
    private void GenerateSpells()
    {
            
    }

    private void GeneratePlayers()
    {
        for (var i = 0; i < Players.Length; i++)
        {
            Players[i] = CreatePlayer();
        }
    }

    private Player CreatePlayer()
    {
        return new Player((Sex)_random.Next(0, 1), (Color)_random.Next(0, 5));
    }
}