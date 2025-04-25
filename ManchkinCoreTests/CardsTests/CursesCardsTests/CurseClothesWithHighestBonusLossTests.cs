using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using ManchkinCoreTests.CardsForTest;
using ManchkinCoreTests.PlayerTests;
using Xunit;

namespace ManchkinCoreTests.CardsTests.CursesCardsTests;

public class CurseClothesWithHighestBonusLossTests
{
    private readonly CurseClothesWithHighestBonusLoss _curseClothesWithHighestBonusLoss = new();
    private readonly TestHelper _testHelper = new();
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_GetTitle_TitleCorrect()
    {
        _curseClothesWithHighestBonusLoss.Title.Should().Be("Сдаём на подарки! Потеряй шмотку с наибольшим бонусом");
    }
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_GetOneTimeCurseFlag_OneTimeCurse()
    {
        _curseClothesWithHighestBonusLoss.OneTimeCurse.Should().BeTrue();
    }

    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_Curse_SmutWithHighestBonusLost()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var curse = new CurseClothesWithHighestBonusLoss();
        player.Inventory.Head = new Ukokoshnik();
        
        curse.Curse(player);

        player.Inventory.Head.Should().BeNull();
    }
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_Curse_VestWithHighestBonusLost()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var curse = new CurseClothesWithHighestBonusLoss();
        player.Inventory.Torso = new BigVest();
        
        curse.Curse(player);

        player.Inventory.Torso.Should().BeNull();
    }
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_Curse_ShoesWithHighestBonusLost()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var curse = new CurseClothesWithHighestBonusLoss();
        player.Inventory.Legs = new BigShoes();
        
        curse.Curse(player);

        player.Inventory.Legs.Should().BeNull();
    }
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_Curse_LeftOneHandWeaponWithHighestBonusLost()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var curse = new CurseClothesWithHighestBonusLoss();
        player.Inventory.LeftHand = new SmallWeapon();
        
        curse.Curse(player);

        player.Inventory.LeftHand.Should().BeNull();
    }
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_Curse_RightOneHandWeaponWithHighestBonusLost()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var curse = new CurseClothesWithHighestBonusLoss();
        var leftHandWeapon = new SmallWeapon();
        var rightHandWeapon = new BigWeapon();
        player.Inventory.LeftHand = leftHandWeapon;
        player.Inventory.RightHand = rightHandWeapon;
        
        curse.Curse(player);

        player.Inventory.RightHand.Should().BeNull();
        player.Inventory.LeftHand.Should().Be(leftHandWeapon);
    }
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_Curse_TwoHandWeaponWithHighestBonusLost()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var curse = new CurseClothesWithHighestBonusLoss();
        var weapon = new SmallTwoHandsWeapon();
        player.Inventory.LeftHand = weapon;
        player.Inventory.RightHand = weapon;
        
        curse.Curse(player);

        player.Inventory.RightHand.Should().BeNull();
        player.Inventory.LeftHand.Should().BeNull();
    }
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_Curse_AdditionalBonusWithHighestBonusLost()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var curse = new CurseClothesWithHighestBonusLoss();
        var title = new TrulyImpressiveTitle();
        player.Inventory.PutOn(title);
        
        curse.Curse(player);

        player.Inventory.Additional.Should().BeEmpty();
    }
}