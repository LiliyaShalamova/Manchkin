using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Player;

namespace Manchkin.Core.Players;

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
    public IPlayerClass? MainClass { get; private set; }
    
    /// <summary>
    /// Дополнительный класс, если игрок - супеманчкин
    /// </summary>
    public IPlayerClass? AdditionalClass { get; private set; }
    
    /// <summary>
    /// Раса
    /// </summary>
    public IRace? Race { get; private set; }
    
    /// <summary>
    /// Цвет
    /// </summary>
    public Color Color { get; private set; }
    
    /// <summary>
    /// Проклятия
    /// </summary>
    public List<ICurse> Curses { get; private set; }
    
    /// <summary>
    /// Инвентарь
    /// </summary>
    public Inventory Inventory { get; private set; } = new();
    
    /// <summary>
    /// Карты на руках
    /// </summary>
    public List<ICard> Cards { get; private set; }

    /// <summary>
    /// Боевая сила
    /// </summary>
    public int FightingStrength => Level + Inventory.GetCommonBonus();

    public bool Dead { get; private set; }

    internal Player(Sex sex, Color color, List<ICard> cards)
    {
        Sex = sex;
        Color = color;
        Level = 1;
        Inventory = new Inventory();
        Curses = [];
        Cards = cards;
        Dead = false;
    }
    
    internal void IncreaseLevel(int levelsCount)
    {
        Level += levelsCount;
    }

    public void DecreaseLevel(int levelsCount) //TODO был internal, но как тогда из програма релазиовывать интерфейс
    {
        Level = Level - levelsCount >= 1 ? Level - levelsCount : 1;
    }

    internal void RemoveCurses()
    {
        Curses.Clear();
    }

    internal void AddCurse(ICurse curse)
    {
        Curses.Add(curse);
    }

    internal void LoseClass()
    {
        MainClass = null;
        AdditionalClass = null;
    }

    internal void Die()
    {
        Dead = true;
        Inventory.Clear();
        Cards.Clear();
    }
}