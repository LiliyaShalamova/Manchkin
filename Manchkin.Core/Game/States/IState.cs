using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Game.States;

internal interface IState
{
    CommandResult Dress(IClothes[] clothes);
    CommandResult Drop(ICard[] cards);
    CommandResultWith<bool> Sell(ITreasure[] treasures);
    CommandResultWith<bool> Finish();
    CommandResultWith<bool> Curse(Players.Player to, ICurse curse);
    CommandResultWith<bool> Cast(IFightingSpell spell);
    CommandResultWith<bool> Cast(IOtherSpell spell);
    CommandResultWith<bool> Monster(IMonster monster);
    CommandResultWith<IDoor> PullDoor();
    CommandResultWith<bool> Run();
    List<Command> GetAllowCommands();
    CommandResultWith<bool> Fight();
}