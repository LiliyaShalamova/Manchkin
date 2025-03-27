using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core;

public interface IState
{
    public void PutOn(Player player, Clothes[] clothes);
    public void Drop(Player player, Card[] cards);
    public bool Sell(Player player, Treasure[] treasures);
    public bool Next(Player player, bool lastPlayer);
    public void Curse(Player from, Player to, ICurse curse);
    public bool Cast(Player player, Spell spell);
    public bool Monster(Player player, Monster monster);
    public Door Door(Player player);
    public bool GetAway(Player player);
    public List<Command> GetAllowCommands();
    
    public void Finish(Player player);
    
    public bool Fight(Player player);
}