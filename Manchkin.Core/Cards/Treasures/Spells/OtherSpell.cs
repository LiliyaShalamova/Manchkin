namespace Manchkin.Core.Cards.Treasures.Spells;

public class OtherSpell : Spell
{
    /// <summary>
    /// Получи уровень
    /// </summary>
    public int LevelBonus { get;}
    
    /// <summary>
    /// Снять проклятие
    /// </summary>
    public bool CurseBonus { get;}
    
    /// <summary>
    /// Количество сокровищ
    /// </summary>
    public int TreasuresBonus { get;}

    public OtherSpell(int price, string title, int washBonus, int levelBonus, bool curseBonus, int treasuresBonus)
    {
        LevelBonus = levelBonus;
        CurseBonus = curseBonus;
        TreasuresBonus = treasuresBonus;
        Price = price;
        Title = title;
        WashBonus = washBonus;
    }

    public override void Print()
    {
        var wash = WashBonus != 0 ? $" Бонус на смывку {WashBonus}" : "";
        var level = LevelBonus != 0 ? $" Получи уровень: {LevelBonus}" : "";
        var curse = CurseBonus ? $" Снимает проклятие" : "";
        var treasures = TreasuresBonus != 0 ? $" Возьми сокровища {TreasuresBonus}" : "";
        Console.WriteLine($"{Title} Цена {Price}{wash}{level}{curse}{treasures}");
    }
}