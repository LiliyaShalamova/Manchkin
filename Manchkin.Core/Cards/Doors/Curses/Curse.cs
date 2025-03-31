namespace Manchkin.Core.Cards.Doors.Curses;

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

    protected Curse(string title)
    {
        Title = title;
    }
}