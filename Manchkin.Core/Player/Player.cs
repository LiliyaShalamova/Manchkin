namespace Manchkin.Core;

/// <summary>
/// Класс игрока
/// </summary>
public class Player
{
    /// <summary>
    /// Пол
    /// </summary>
    public Sex Sex { get; private set; }
    
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level { get; private set; }
    
    /// <summary>
    /// Основной класс
    /// </summary>
    public PlayerClass? MainClass { get; private set; }
    
    /// <summary>
    /// Дополнительный класс, если игрок - супеманчкин
    /// </summary>
    public PlayerClass? AdditionalClass { get; private set; }
    
    /// <summary>
    /// Раса
    /// </summary>
    public Race? Race { get; private set; }
    
    /// <summary>
    /// Цвет
    /// </summary>
    public Color Color { get; private set; }
    
    /// <summary>
    /// Проклятия
    /// </summary>
    public List<Curse> Curses { get; private set; }
    
    /// <summary>
    /// Инвентарь
    /// </summary>
    public Inventory Inventory { get; private set; } = new();
    
    /// <summary>
    /// Карты на руках
    /// </summary>
    public List<Card> Cards { get; private set; }

    /// <summary>
    /// Боевая сила
    /// </summary>
    public int FightingStrength => Level + Inventory.GetCommonBonus();

    public bool Dead = false;

    public Player(Sex sex, Color color, List<Card> cards)
    {
        Sex = sex;
        Color = color;
        Level = 1;
        Inventory = new Inventory();
        Curses = [];
        Cards = cards;
    }

    public void IncreaseLevel(int levelsCount) // TODO, если уровень 9, то повышать карточкой уровня нельзя
    {
        Level += levelsCount;
    }

    public void DecreaseLevel(int levelsCount)
    {
        Level = Level - levelsCount >= 1 ? Level - levelsCount : 1;
    }

    public void RemoveCurses()
    {
        Curses.Clear();
    }

    public void AddCurse(Curse curse)
    {
        
    }

    public void LoseClass()
    {
        MainClass = null;
        AdditionalClass = null;
    }

    public void Die()
    {
        Dead = true;
        Inventory.Clear();
        Cards.Clear();
    }
}