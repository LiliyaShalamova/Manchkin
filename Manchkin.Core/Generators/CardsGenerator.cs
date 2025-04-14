using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;

namespace Manchkin.Core.Generators;

internal class CardsGenerator : ICardsGenerator
{
    private readonly IRandom _random;
    private readonly CardsStorage _storage;

    public CardsGenerator(CardsStorage cardsStorage, IRandom random)
    {
        _storage = cardsStorage;
        _random = random;
    }
    
    public ITreasure GetTreasureCard()
    {
        return GetGenerator<ITreasure>().First();
    }

    public IDoor GetDoorCard()
    {
        return GetGenerator<IDoor>().First();
    }
    
    private IEnumerable<T> GetGenerator<T>()
    {
        var typeCount = _storage.GetTypeCount<T>();
        while (true)
        {
            yield return (T)Activator.CreateInstance(_storage.GetTypeByIndex<T>(_random.Next(0, typeCount)))!;
        }
    }
}