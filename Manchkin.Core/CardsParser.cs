using System.Security.AccessControl;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Microsoft.VisualBasic.FileIO;

namespace Manchkin.Core;

public interface ICardParser<T>
{
    public List<T> Parse();
}

public abstract class CardParser
{
    private readonly string _delimiters = ";";
    private readonly string[] _commentTokens = ["/*"];
    private protected string CurrentDirectory = Directory.GetCurrentDirectory();

    protected TextFieldParser GetTextFieldParser(string path)
    {
        var parser = new TextFieldParser(path);
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(_delimiters);
        parser.CommentTokens = _commentTokens;

        return parser;
    }
}

public class ClothesParser : CardParser, ICardParser<Clothes>
{
    private string _clothesPath = @"\Manchkin.Core\Cards\CardsFiles\Clothes.txt";

    public List<Clothes> Parse()
    {
        var fullCursesPath = $"{CurrentDirectory}{_clothesPath}";
        var parser = GetTextFieldParser(fullCursesPath);
        var clothes = new List<Clothes>();
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            var clothesType = fields![0];
            var bonus = int.Parse(fields[1]);
            var price = int.Parse(fields[2]);
            var title = fields[3];
            var isBig = Convert.ToBoolean(int.Parse(fields[4]));
            var wash = int.Parse(fields[5]);
            Clothes clothesItem = clothesType switch
            {
                "Additional" => new Additional(bonus, price, title, isBig, wash),
                "Weapon" => new Weapon(bonus, price, title, isBig, wash, int.Parse(fields[6])),
                "Shoes" => new Shoes(bonus, price, title, isBig, wash),
                "BulletproofVest" => new BulletproofVest(bonus, price, title, isBig, wash),
                "Smut" => new Smut(bonus, price, title, isBig, wash),
                _ => throw new Exception($"Unknown card type: {clothesType}")
            };
            clothes.Add(clothesItem);
        }

        return clothes;
    }
}

public class SpellParser : CardParser, ICardParser<Spell>
{
    private string _spellsPath = @"\Manchkin.Core\Cards\CardsFiles\Spells.txt";

    public List<Spell> Parse()
    {
        var fullCursesPath = $"{CurrentDirectory}{_spellsPath}";
        var parser = GetTextFieldParser(fullCursesPath);
        var spells = new List<Spell>();
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            var spellType = fields![0];
            var price = int.Parse(fields[1]);
            var title = fields[2];
            var washBonus = int.Parse(fields[3]);
            Spell spellItem = spellType switch
            {
                "Other" => GetOtherSpell(price, title, washBonus, fields),
                "Fighting" => GetFightingSpell(price, title, washBonus, fields),
                _ => throw new Exception($"Unknown card type: {spellType}")
            };
            spells.Add(spellItem);
        }

        return spells;
    }

    private Spell GetOtherSpell(int price, string title, int washBonus, string[] fields)
    {
        Spell? spell = null;
        if (int.Parse(fields[4]) != 0)
        {
            spell = new LevelOtherSpell(price, title, washBonus, int.Parse(fields[4]));
        }
        else if (int.Parse(fields[6]) != 0)
        {
            spell = new TreasuresBonusOtherSpell(price, title, washBonus, int.Parse(fields[6]));
        }
        else if (int.Parse(fields[7]) != 0)
        {
            spell = new CurseBonusOtherSpell(price, title, washBonus);
        }
        return spell;
    }

    private Spell GetFightingSpell(int price, string title, int washBonus, string[] fields)
    {
        Spell? spell = null;
        if (washBonus != 0)
        {
            spell = new WashBonusOtherSpell(price, title, washBonus);
        }
        else if (int.Parse(fields[5]) != 0)
        {
            spell = new DamageBonusOtherSpell(price, title, washBonus, int.Parse(fields[5]));
        }
        else if (int.Parse(fields[8]) != 0)
        {
            spell = new MonstersDeathOtherSpell(price, title, washBonus);
        }
        
        return spell;
    }
}

public class MonsterParser : CardParser, ICardParser<Monster>
{
    private string _monstersPath = @"\Manchkin.Core\Cards\CardsFiles\Monsters.txt";

    public List<Monster> Parse()
    {
        var fullCursesPath = $"{CurrentDirectory}{_monstersPath}";
        var parser = GetTextFieldParser(fullCursesPath);
        var monsters = new List<Monster>();
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            var level = int.Parse(fields![0]);
            var name = fields[1];
            var treasuresCount = int.Parse(fields[2]);
            var levelsCount = int.Parse(fields[3]);
            var death = Convert.ToBoolean(int.Parse(fields[4]));
            var doesNotFightLevel = int.Parse(fields[5]);
            var levelLossCount = int.Parse(fields[6]);
            var playerClassLoss = Convert.ToBoolean(int.Parse(fields[7]));
            var shoesLoss = Convert.ToBoolean(int.Parse(fields[8]));
            var armorLoss = Convert.ToBoolean(int.Parse(fields[9]));
            Monster monster = null;
            if (death)
            {
                monster = new DeathMonster(level, name, treasuresCount, levelsCount, doesNotFightLevel);
            }
            else if (levelLossCount != 0)
            {
                monster = new LevelLossMonster(level, name, treasuresCount, levelsCount, doesNotFightLevel, levelLossCount);
            }
            else if (shoesLoss)
            {
                monster = new ShoesLossMonster(level, name, treasuresCount, levelsCount, doesNotFightLevel);
            }
            else if (armorLoss)
            {
                monster = new ArmorLossMonster(level, name, treasuresCount, levelsCount, doesNotFightLevel);
            }
            else if (playerClassLoss)
            {
                monster = new PlayerClassLossMonster(level, name, treasuresCount, levelsCount, doesNotFightLevel);
            }
            
            monsters.Add(monster);
        }

        return monsters;
    }
}

public class CurseParser : CardParser, ICardParser<Curse>
{
    private string _cursesPath = @"\Manchkin.Core\Cards\CardsFiles\Curses.txt";

    public List<Curse> Parse()
    {
        var fullCursesPath = $"{CurrentDirectory}{_cursesPath}";
        var parser = GetTextFieldParser(fullCursesPath);
        var curses = new List<Curse>();
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            var title = fields![0];
            var clothesWithHighestBonusLoss = Convert.ToBoolean(int.Parse(fields[1]));
            var playersClassLoss = Convert.ToBoolean(int.Parse(fields[2]));
            var shoesLoss = Convert.ToBoolean(int.Parse(fields[3]));
            var armorLoss = Convert.ToBoolean(int.Parse(fields[4]));
            var levelLossCount = int.Parse(fields[5]);
            Curse curse = null;
            if (clothesWithHighestBonusLoss)
            {
                curse = new CurseClothesWithHighestBonusLoss(title);
            }
            else if (playersClassLoss)
            {
                curse = new CursePlayersClassLoss(title);
            }
            else if (shoesLoss)
            {
                curse = new CurseShoesLoss(title);
            }
            else if (armorLoss)
            {
                curse = new CurseArmorLoss(title);
            }
            else if (levelLossCount != 0)
            {
                curse = new CurseLevelLoss(title, levelLossCount);
            }

            curses.Add(curse);
        }

        return curses;
    }
}