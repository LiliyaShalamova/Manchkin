using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;

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

    public T GetCard<T>() where T : ICard
    {
        return GetGenerator<T>().First();
    }
    
    private IEnumerable<T> GetGenerator<T>()
    {
        var typeCount = _storage.GetTypeCount<T>();
        while (true)
        {
            yield return (T)Activator.CreateInstance(_storage.GetTypeByIndex<T>(_random.Next(0, typeCount)))!; //TODO исправлено
        }
    }
}