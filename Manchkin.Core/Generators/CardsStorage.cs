using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core.Generators;

internal class CardsStorage
{
    private readonly List<Type> _treasuresCardsTypes = [];
    private readonly List<Type> _doorsCardsTypes = [];
    public void RegisterCurse<T>() where T : ICurse, new()
    {
        _doorsCardsTypes.Add(typeof(T));
    }
    
    public void RegisterMonster<T>() where T : IMonster, new()
    {
        _doorsCardsTypes.Add(typeof(T));
    }
    
    public void RegisterAdditionalClothes<T>() where T : IAdditional, new()
    {
        _treasuresCardsTypes.Add(typeof(T));
    }
    
    public void RegisterShoes<T>() where T : IShoes, new()
    {
        _treasuresCardsTypes.Add(typeof(T));
    }
    
    public void RegisterSmut<T>() where T : ISmut, new()
    {
        _treasuresCardsTypes.Add(typeof(T));
    }
    
    public void RegisterVest<T>() where T : IVest, new()
    {
        _treasuresCardsTypes.Add(typeof(T));
    }
    
    public void RegisterWeapon<T>() where T : IWeapon, new()
    {
        _treasuresCardsTypes.Add(typeof(T));
    }
    
    public void RegisterFightingSpell<T>() where T : IFightingSpell, new()
    {
        _treasuresCardsTypes.Add(typeof(T));
    }
    
    public void RegisterOtherSpell<T>() where T : IOtherSpell, new()
    {
        _treasuresCardsTypes.Add(typeof(T));
    }

    public Type GetTypeByIndex<T>(int index)
    {
        return typeof(T) == typeof(ITreasure) ? _treasuresCardsTypes[index] : _doorsCardsTypes[index];
    }

    public int GetTypeCount<T>()
    {
        return typeof(T) == typeof(ITreasure) ? _treasuresCardsTypes.Count : _doorsCardsTypes.Count;
    }
}