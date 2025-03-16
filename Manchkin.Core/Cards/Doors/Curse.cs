namespace Manchkin.Core;

/// <summary>
/// Класс Проклятие
/// </summary>
public class Curse : Door
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get;}
    
    /// <summary>
    /// Потеряй штомку с наибольшим бонусом
    /// </summary>
    public bool ClothesWithHighestBonusLoss { get; }
    
    /// <summary>
    /// Потеряй класс
    /// </summary>
    public bool PlayersClassLoss { get;}
    
    /// <summary>
    /// Потеряй обувку
    /// </summary>
    public bool ShoesLoss { get;}
    
    /// <summary>
    /// Потеряй броню
    /// </summary>
    public bool ArmorLoss { get;}
    
    /// <summary>
    /// Потеряй уровень
    /// </summary>
    public int LevelLossCount { get;}
    
    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get;}

    public Curse(string title, bool clothesWithHighestBonusLoss, bool playersClassLoss, bool shoesLoss, bool armorLoss, int levelLossCount)
    {
        Title = title;
        ClothesWithHighestBonusLoss = clothesWithHighestBonusLoss;
        PlayersClassLoss = playersClassLoss;
        ShoesLoss = shoesLoss;
        ArmorLoss = armorLoss;
        LevelLossCount = levelLossCount;
    }

    public override void Print()
    {
        Console.WriteLine($"Карта Проклятие. {Title}");
    }
}