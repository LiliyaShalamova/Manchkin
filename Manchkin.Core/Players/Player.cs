using System.Collections.Immutable;
using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;

namespace Manchkin.Core.Players;

/// <summary>
/// Класс игрока
/// </summary>
public class Player : PublicPlayer
{
    /// <summary>
    /// Боевая сила
    /// </summary>
    public int FightingStrength => Level + Inventory.GetCommonBonus();

    internal Player(Sex sex, Color color, ImmutableList<ICard> cards)
    {
        Sex = sex;
        Color = color;
        Level = 1;
        Inventory = new Inventory();
        Curses = [];
        Cards = cards;
        Dead = false;
    }
    
    public void IncreaseLevel(int levelsCount)
    {
        Level += levelsCount;
    }

    public void DecreaseLevel(int levelsCount)
    {
        Level = Level - levelsCount >= 1 ? Level - levelsCount : 1;
    }

    public void RemoveCurses()
    {
        Curses = Curses.Clear();
    }

    public void AddCurse(ICurse curse)
    {
        Curses = Curses.Add(curse);
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
        Cards = Cards.Clear();
    }
}