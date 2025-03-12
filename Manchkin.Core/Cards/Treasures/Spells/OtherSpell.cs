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
}