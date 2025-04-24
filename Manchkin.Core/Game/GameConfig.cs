using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;

namespace Manchkin.Core.Game;

public class GameConfig
{
    /// <summary>
    /// Количество игроков
    /// </summary>
    public int PlayersCount { get; init; }
    
    /// <summary>
    /// Количество карт в руке каждого типа на старте игры
    /// </summary>
    public int CardsNumberOfEachType => 4;

    /// <summary>
    /// Использовать дефолтные карты. Если false, используются только свои карты
    /// </summary>
    public bool UseDefaultCards => true;

    public int LevelsCount => 10;
    internal CardsStorage CardsStorage { get; } = new();

    public GameConfig RegisterAdditionalClothes<T>() where T : IAdditional, new()
    {
        CardsStorage.RegisterAdditionalClothes<T>();
        return this;
    }
    
    public GameConfig RegisterShoes<T>() where T : IShoes, new()
    {
        CardsStorage.RegisterShoes<T>();
        return this;
    }
    
    public GameConfig RegisterSmut<T>() where T : ISmut, new()
    {
        CardsStorage.RegisterSmut<T>();
        return this;
    }
    
    public GameConfig RegisterVest<T>() where T : IVest, new()
    {
        CardsStorage.RegisterVest<T>();
        return this;
    }
    
    public GameConfig RegisterWeapon<T>() where T : IWeapon, new()
    {
        CardsStorage.RegisterWeapon<T>();
        return this;
    }

    public GameConfig RegisterFightingSpell<T>() where T : IFightingSpell, new()
    {
        CardsStorage.RegisterFightingSpell<T>();
        return this;
    }

    public GameConfig RegisterOtherSpell<T>() where T : IOtherSpell, new()
    {
        CardsStorage.RegisterOtherSpell<T>();
        return this;
    }

    public GameConfig RegisterMonster<T>() where T : IMonster, new()
    {
        CardsStorage.RegisterMonster<T>();
        return this;
    }

    public GameConfig RegisterCurse<T>() where T : ICurse, new()
    {
        CardsStorage.RegisterCurse<T>();
        return this;
    }
}