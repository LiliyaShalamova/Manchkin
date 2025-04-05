using Manchkin.Core.Cards.Doors.Monsters;

namespace Manchkin.Core.Parser;
/*
internal class MonsterParser : CardParser, ICardParser<IMonster>
{
    private string _monstersPath = @"\Manchkin.Core\Cards\CardsFiles\Monsters.txt";

    public List<IMonster> Parse()
    {
        var fullCursesPath = $"{CurrentDirectory}{_monstersPath}";
        var parser = GetTextFieldParser(fullCursesPath);
        var monsters = new List<IMonster>();
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
            IMonster monster = null;
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
}*/