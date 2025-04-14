using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

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
    public int CardsNumberOfEachType { get; init; } = 4;
    
    /// <summary>
    /// Использовать дефолтные карты. Если false, используются только свои карты
    /// </summary>
    public bool UseDefaultCards { get; init; } = true;

    public int LevelsCount { get; init; } = 10;
    internal CardsStorage CardsStorage { get; } = new();

    public GameConfig RegisterClothes<T>() where T : IClothes, new()
    {
        CardsStorage.RegisterClothes<T>();
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