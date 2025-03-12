using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Microsoft.VisualBasic.FileIO;

namespace Manchkin.Core;

public class CardsParser
{
    public List<T> ParseByDelimiters<T>(string path, string? delimiters, string[]? commentTokens = null) where T : Card
    {
        using var parser = new TextFieldParser(path);
        if (delimiters != null)
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(delimiters);
        }

        if (commentTokens != null)
        {
            parser.CommentTokens = commentTokens;
        }

        return typeof(T).Name switch
        {
            "Clothes" => (ParseClothes(parser) as List<T>)!,
            "Spell" => (ParseSpells(parser) as List<T>)!,
            "Monster" => (ParseMonsters(parser) as List<T>)!,
            "Curse" => (ParseCurses(parser) as List<T>)!,
            _ => throw new Exception($"Unknown card type: {typeof(T).Name}")
        };
    }

    private List<Clothes> ParseClothes(TextFieldParser parser)
    {
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
            var clothesItem = clothesType switch
            {
                "Additional" => new Clothes(bonus, price, title, isBig, wash),
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

    private List<Spell> ParseSpells(TextFieldParser parser)
    {
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
                "Other" => new OtherSpell(price, title, washBonus, int.Parse(fields[4]),
                    Convert.ToBoolean(int.Parse(fields[7])), int.Parse(fields[6])),
                "Fighting" => new FightingSpell(price, title, washBonus, int.Parse(fields[5]),
                    Convert.ToBoolean(int.Parse(fields[8]))),
                _ => throw new Exception($"Unknown card type: {spellType}")
            };
            spells.Add(spellItem);
        }

        return spells;
    }
    
    private List<Monster> ParseMonsters(TextFieldParser parser)
    {
        var monsters = new List<Monster>();
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            var level = int.Parse(fields![0]);
            var name = fields[1];
            var treasuresCount = int.Parse(fields[2]);
            var levelsCount = int.Parse(fields[3]);
            var death =Convert.ToBoolean(int.Parse(fields[4]));
            var doesNotFightLevel = int.Parse(fields[5]);
            var levelLossCount = int.Parse(fields[6]);
            var playerClassLoss = Convert.ToBoolean(int.Parse(fields[7]));
            var shoesLoss = Convert.ToBoolean(int.Parse(fields[8]));
            var armorLoss = Convert.ToBoolean(int.Parse(fields[9]));
            var monster = new Monster(level, name, treasuresCount, levelsCount, death, doesNotFightLevel,
                levelLossCount, playerClassLoss, shoesLoss, armorLoss);
            monsters.Add(monster);
        }

        return monsters;
    }
    
    private List<Curse> ParseCurses(TextFieldParser parser)
    {
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
            var curse = new Curse(title, clothesWithHighestBonusLoss, playersClassLoss, shoesLoss, armorLoss, levelLossCount);
            curses.Add(curse);
        }

        return curses;
    }
}