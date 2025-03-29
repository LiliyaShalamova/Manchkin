using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core;

public interface IState
{
    public void PutOn(Clothes[] clothes);
    public void Drop(Card[] cards);
    public bool Sell(Treasure[] treasures);
    public bool Next();
    public void Curse(Player to, ICurse curse);
    public bool Cast(Spell spell);
    public bool Monster(Monster monster);
    public Door Door();
    public bool GetAway();
    public List<Command> GetAllowCommands();
    public void Finish();
    public bool Fight();
}