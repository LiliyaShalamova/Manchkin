using FluentAssertions;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Generators;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;
using ManchkinCoreTests.PlayerTests;
using Xunit;

namespace ManchkinCoreTests.GameTests;

public class CardsStorageTests
{
    [Fact]
    public void CardsStorageCreated_RegisterAdditionalClothes_Registered()
    {
        var cardsStorage = new CardsStorage();

        cardsStorage.RegisterAdditionalClothes<TrulyImpressiveTitle>();
        
        var treasureType = cardsStorage.GetTypeByIndex<ITreasure>(0);
        treasureType.Should().Be(typeof(TrulyImpressiveTitle));
    }
    
    [Fact]
    public void CardsStorageCreated_RegisterShoes_Registered()
    {
        var cardsStorage = new CardsStorage();

        cardsStorage.RegisterShoes<FeltBoots>();
        
        var treasureType = cardsStorage.GetTypeByIndex<ITreasure>(0);
        treasureType.Should().Be(typeof(FeltBoots));
    }
    
    [Fact]
    public void CardsStorageCreated_RegisterSmut_Registered()
    {
        var cardsStorage = new CardsStorage();

        cardsStorage.RegisterSmut<Ukokoshnik>();
        
        var treasureType = cardsStorage.GetTypeByIndex<ITreasure>(0);
        treasureType.Should().Be(typeof(Ukokoshnik));
    }
    
    [Fact]
    public void CardsStorageCreated_RegisterVest_Registered()
    {
        var cardsStorage = new CardsStorage();

        cardsStorage.RegisterVest<ShortVest>();
        
        var treasureType = cardsStorage.GetTypeByIndex<ITreasure>(0);
        treasureType.Should().Be(typeof(ShortVest));
    }
    
    [Fact]
    public void CardsStorageCreated_RegisterWeapon_Registered()
    {
        var cardsStorage = new CardsStorage();

        cardsStorage.RegisterWeapon<SmallWeapon>();
        
        var treasureType = cardsStorage.GetTypeByIndex<ITreasure>(0);
        treasureType.Should().Be(typeof(SmallWeapon));
    }
    
    [Fact]
    public void CardsStorageCreated_RegisterFightingSpell_Registered()
    {
        var cardsStorage = new CardsStorage();

        cardsStorage.RegisterFightingSpell<ZelenkaFightingSpell>();
        
        var treasureType = cardsStorage.GetTypeByIndex<ITreasure>(0);
        treasureType.Should().Be(typeof(ZelenkaFightingSpell));
    }
    
    [Fact]
    public void CardsStorageCreated_RegisterOtherSpell_Registered()
    {
        var cardsStorage = new CardsStorage();

        cardsStorage.RegisterOtherSpell<GoToBathhouseGetLevelOtherSpell>();
        
        var treasureType = cardsStorage.GetTypeByIndex<ITreasure>(0);
        treasureType.Should().Be(typeof(GoToBathhouseGetLevelOtherSpell));
    }
    
    [Fact]
    public void CardsStorageCreated_RegisterMonster_Registered()
    {
        var cardsStorage = new CardsStorage();

        cardsStorage.RegisterMonster<BabaYaga>();
        
        var treasureType = cardsStorage.GetTypeByIndex<IDoor>(0);
        treasureType.Should().Be(typeof(BabaYaga));
    }
    
    [Fact]
    public void CardsStorageCreated_RegisterCurse_Registered()
    {
        var cardsStorage = new CardsStorage();

        cardsStorage.RegisterCurse<CurseClothesWithHighestBonusLoss>();
        
        var treasureType = cardsStorage.GetTypeByIndex<IDoor>(0);
        treasureType.Should().Be(typeof(CurseClothesWithHighestBonusLoss));
    }
    
    [Fact]
    public void CardsStorageCreated_GetTreasureCount_CountCorrect()
    {
        var cardsStorage = new CardsStorage();
        cardsStorage.RegisterVest<ShortVest>();
        
        var count = cardsStorage.GetTypeCount<ITreasure>();
        
        count.Should().Be(1);
    }
    
    [Fact]
    public void CardsStorageCreated_GetDoorCount_CountCorrect()
    {
        var cardsStorage = new CardsStorage();
        cardsStorage.RegisterCurse<CurseClothesWithHighestBonusLoss>();
        
        var count = cardsStorage.GetTypeCount<IDoor>();
        
        count.Should().Be(1);
    }
}