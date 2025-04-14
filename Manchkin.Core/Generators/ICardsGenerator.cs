using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;

namespace Manchkin.Core.Generators;

public interface ICardsGenerator
{
    ITreasure GetTreasureCard();
    IDoor GetDoorCard();
}