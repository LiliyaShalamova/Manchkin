namespace Manchkin.Core.Parser;
/*
internal class ClothesParser : CardParser, ICardParser<IClothes>
{
    
    private string _clothesPath = @"\Manchkin.Core\Cards\CardsFiles\Clothes.txt";

    public List<IClothes> Parse()
    {
        var fullCursesPath = $"{CurrentDirectory}{_clothesPath}";
        var parser = GetTextFieldParser(fullCursesPath);
        var clothes = new List<IClothes>();
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            var clothesType = fields![0];
            var bonus = int.Parse(fields[1]);
            var price = int.Parse(fields[2]);
            var title = fields[3];
            var isBig = Convert.ToBoolean(int.Parse(fields[4]));
            var wash = int.Parse(fields[5]);
            IClothes clothesItem = clothesType switch
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
}*/