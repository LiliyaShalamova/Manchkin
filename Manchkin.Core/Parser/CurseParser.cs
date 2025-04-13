
/*
namespace Manchkin.Core.Parser;

internal class CurseParser : CardParser, ICardParser<ICurse>
{
    private string _cursesPath = @"\Manchkin.Core\Cards\CardsFiles\Curses.txt";

    public List<ICurse> Parse()
    {
        var fullCursesPath = $"{CurrentDirectory}{_cursesPath}";
        var parser = GetTextFieldParser(fullCursesPath);
        var curses = new List<ICurse>();
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            var title = fields![0];
            var clothesWithHighestBonusLoss = Convert.ToBoolean(int.Parse(fields[1]));
            var playersClassLoss = Convert.ToBoolean(int.Parse(fields[2]));
            var shoesLoss = Convert.ToBoolean(int.Parse(fields[3]));
            var armorLoss = Convert.ToBoolean(int.Parse(fields[4]));
            var levelLossCount = int.Parse(fields[5]);
            ICurse curse = null;
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
}*/