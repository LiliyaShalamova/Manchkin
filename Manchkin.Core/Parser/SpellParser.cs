using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Parser;
/*
internal class SpellParser : CardParser, ICardParser<ISpell>
{
    private string _spellsPath = @"\Manchkin.Core\Cards\CardsFiles\Spells.txt";

    public List<ISpell> Parse()
    {
        var fullCursesPath = $"{CurrentDirectory}{_spellsPath}";
        var parser = GetTextFieldParser(fullCursesPath);
        var spells = new List<ISpell>();
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            var spellType = fields![0];
            var price = int.Parse(fields[1]);
            var title = fields[2];
            var washBonus = int.Parse(fields[3]);
            ISpell spellItem = spellType switch
            {
                "Other" => GetOtherSpell(price, title, washBonus, fields),
                "Fighting" => GetFightingSpell(price, title, washBonus, fields),
                _ => throw new Exception($"Unknown card type: {spellType}")
            };
            spells.Add(spellItem);
        }

        return spells;
    }

    private ISpell GetOtherSpell(int price, string title, int washBonus, string[] fields)
    {
        ISpell? spell = null;
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

    private ISpell GetFightingSpell(int price, string title, int washBonus, string[] fields)
    {
        ISpell? spell = null;
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
}*/