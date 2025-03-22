namespace Manchkin.Core;

/// <summary>
/// Класс Проклятие
/// </summary>
public abstract class Curse : Door
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title { get;}
    
    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get;}

    public Curse(string title)
    {
        Title = title;
    }

    /*public override void Print()
    {
        Console.WriteLine($"Карта Проклятие. {Title}");
    }*/
}