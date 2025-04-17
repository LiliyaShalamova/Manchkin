using System.Collections.Immutable;
using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;

namespace Manchkin.Core.Players;

public class PublicPlayer
{
    /// <summary>
    /// Пол
    /// </summary>
    public Sex Sex { get; internal set; }
    
    /// <summary>
    /// Уровень
    /// </summary>
    public int Level { get; internal set; }
    
    /// <summary>
    /// Основной класс
    /// </summary>
    public IPlayerClass? MainClass { get; internal set; }
    
    /// <summary>
    /// Дополнительный класс, если игрок - супеманчкин
    /// </summary>
    public IPlayerClass? AdditionalClass { get; internal set; }
    
    /// <summary>
    /// Раса
    /// </summary>
    public IRace? Race { get; internal set; }
    
    /// <summary>
    /// Цвет
    /// </summary>
    public Color Color { get; internal set; }
    
    /// <summary>
    /// Мертв
    /// </summary>
    public bool IsDead { get; internal set; }
    
    /// <summary>
    /// Проклятия
    /// </summary>
    public ImmutableList<ICurse> Curses { get; internal set; }
    
    /// <summary>
    /// Инвентарь
    /// </summary>
    public Inventory Inventory { get; internal set; }
    
    /// <summary>
    /// Карты на руках
    /// </summary>
    public ImmutableList<ICard> Cards { get; internal set; }
}