using FluentAssertions;
using Manchkin.Core;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Player;
using Xunit;

namespace ManchkinCoreTests.PlayerTests;

public class InventoryTests
{
    [Fact]
    public void EmptyHead_PutOnSmut_ReturnedEmpty()
    {
        var inventory = new Inventory();
        var smut = new Smut(1, 100, "Головняк");

        var returnedClothes = inventory.PutOn(smut);

        inventory.Head.Should().Be(smut);
        returnedClothes.Should().BeEmpty();
    }

    [Fact]
    public void NotEmptyHead_PutOnSmut_ReturnedSmut()
    {
        var inventory = new Inventory();
        var smut = new Smut(1, 100, "Головняк");
        var smut2 = new Smut(2, 200, "Головняк2");
        inventory.PutOn(smut);

        var returnedClothes = inventory.PutOn(smut2);

        inventory.Head.Should().Be(smut2);
        returnedClothes.Should().HaveCount(1);
        returnedClothes[0].Should().Be(smut);
    }

    [Fact]
    public void PutOnOneHandWeapon_HandsFree_ToLeftHand()
    {
        var inventory = new Inventory();
        var weapon = new Weapon(1, 100, "Оружие", handsAmount: 1);

        var returnedClothes = inventory.PutOn(weapon);
        
        returnedClothes.Should().BeEmpty();
        inventory.LeftHand.Should().Be(weapon);
        inventory.RightHand.Should().BeNull();
    }
    
    [Fact]
    public void PutOnTwoHandWeapon_HandsFree_ToBothHands()
    {
        var inventory = new Inventory();
        var weapon = new Weapon(1, 100, "Оружие", handsAmount: 2);

        var returnedClothes = inventory.PutOn(weapon);
        
        returnedClothes.Should().BeEmpty();
        inventory.LeftHand.Should().Be(weapon);
        inventory.RightHand.Should().Be(weapon);
    }
    
    [Fact]
    public void PutOnOneHandWeapon_RightHandFree_ToRightHand()
    {
        var inventory = new Inventory();
        var weapon1 = new Weapon(1, 100, "Оружие", handsAmount: 1);
        inventory.PutOn(weapon1);
        var weapon2 = new Weapon(2, 200, "Оружие2", handsAmount: 1);

        var returnedClothes = inventory.PutOn(weapon2);
        
        returnedClothes.Should().BeEmpty();
        inventory.LeftHand.Should().Be(weapon1);
        inventory.RightHand.Should().Be(weapon2);
    }
    
    [Fact]
    public void PutOnTwoHandsWeapon_RightHandFree_ToBothHand()
    {
        var inventory = new Inventory();
        var weapon1 = new Weapon(1, 100, "Оружие", handsAmount: 1);
        inventory.PutOn(weapon1);
        var weapon2 = new Weapon(2, 200, "Оружие2", handsAmount: 2);

        var returnedClothes = inventory.PutOn(weapon2);
        
        returnedClothes.Should().HaveCount(1);
        returnedClothes[0].Should().Be(weapon1);
        inventory.LeftHand.Should().Be(weapon2);
        inventory.RightHand.Should().Be(weapon2);
    }

    [Fact]
    public void PutOnOneHandWeapon_BothHandsBusyDifferent_ToLeftHand()
    {
        var inventory = new Inventory();
        var weapon1 = new Weapon(1, 100, "Оружие", handsAmount: 1);
        var weapon2 = new Weapon(2, 200, "Оружие2", handsAmount: 1);
        inventory.PutOn(weapon1);
        inventory.PutOn(weapon2);
        var weapon3 = new Weapon(3, 300, "Оружие3", handsAmount: 1);
        
        var returnedClothes = inventory.PutOn(weapon3);
        
        returnedClothes.Should().HaveCount(1);
        returnedClothes[0].Should().Be(weapon1);
        inventory.LeftHand.Should().Be(weapon3);
        inventory.RightHand.Should().Be(weapon2);
    }
    
    [Fact]
    public void PutOnTwoHandsWeapon_BothHandsBusyDifferent_ToBothHands()
    {
        var inventory = new Inventory();
        var weapon1 = new Weapon(1, 100, "Оружие", handsAmount: 1);
        var weapon2 = new Weapon(2, 200, "Оружие2", handsAmount: 1);
        inventory.PutOn(weapon1);
        inventory.PutOn(weapon2);
        var weapon3 = new Weapon(3, 300, "Оружие3", handsAmount: 2);
        
        var returnedClothes = inventory.PutOn(weapon3);
        
        returnedClothes.Should().HaveCount(2);
        returnedClothes[0].Should().Be(weapon1);
        returnedClothes[1].Should().Be(weapon2);
        inventory.LeftHand.Should().Be(weapon3);
        inventory.RightHand.Should().Be(weapon3);
    }
    
    [Fact]
    public void PutOnOneHandWeapon_BothHandsBusySame_ToLeftHands()
    {
        var inventory = new Inventory();
        var weapon1 = new Weapon(1, 100, "Оружие", handsAmount: 2);
        inventory.PutOn(weapon1);

        var weapon2 = new Weapon(2, 200, "Оружие2", handsAmount: 1);
        
        var returnedClothes = inventory.PutOn(weapon2);
        
        returnedClothes.Should().HaveCount(1);
        returnedClothes[0].Should().Be(weapon1);
        inventory.LeftHand.Should().Be(weapon2);
        inventory.RightHand.Should().BeNull();
    }
    
    [Fact]
    public void PutOnTwoHandsWeapon_BothHandsBusySame_ToBothHands()
    {
        var inventory = new Inventory();
        var weapon1 = new Weapon(1, 100, "Оружие", handsAmount: 2);
        inventory.PutOn(weapon1);

        var weapon2 = new Weapon(2, 200, "Оружие2", handsAmount: 2);
        
        var returnedClothes = inventory.PutOn(weapon2);
        
        returnedClothes.Should().HaveCount(1);
        returnedClothes[0].Should().Be(weapon1);
        inventory.LeftHand.Should().Be(weapon2);
        inventory.RightHand.Should().Be(weapon2);
    }
    
    [Fact]
    public void EmptyLegs_PutOnShoes_ReturnedEmpty()
    {
        var inventory = new Inventory();
        var shoes = new Shoes(1, 100, "Обувка");

        var returnedClothes = inventory.PutOn(shoes);

        inventory.Legs.Should().Be(shoes);
        returnedClothes.Should().BeEmpty();
    }

    [Fact]
    public void NotEmptyLegs_PutOnShoes_ReturnedShoes()
    {
        var inventory = new Inventory();
        var shoes1 = new Shoes(1, 100, "Обувка1");
        var shoes2 = new Shoes(2, 200, "Обувка2");
        inventory.PutOn(shoes1);

        var returnedClothes = inventory.PutOn(shoes2);

        inventory.Legs.Should().Be(shoes2);
        returnedClothes.Should().HaveCount(1);
        returnedClothes[0].Should().Be(shoes1);
    }

    [Fact]
    public void EmptyTorso_PutOnVest_ReturnedEmpty()
    {
        var inventory = new Inventory();
        var vest = new BulletproofVest(1, 100, "Броник");

        var returnedClothes = inventory.PutOn(vest);

        inventory.Torso.Should().Be(vest);
        returnedClothes.Should().BeEmpty();
    }

    [Fact]
    public void NotEmptyTorso_PutOnVest_ReturnedVest()
    {
        var inventory = new Inventory();
        var vest1 = new BulletproofVest(1, 100, "Броник1");
        var vest2 = new BulletproofVest(2, 200, "Броник2");
        inventory.PutOn(vest1);

        var returnedClothes = inventory.PutOn(vest2);

        inventory.Torso.Should().Be(vest2);
        returnedClothes.Should().HaveCount(1);
        returnedClothes[0].Should().Be(vest1);
    }

    [Fact]
    public void PlayerWithoutAdditionalClothes_PutOnAdditionalClothes_Added()
    {
        var inventory = new Inventory();
        var additional = new Additional(1, 100, "Титул");

        inventory.PutOn(additional);
        
        inventory.Additional.Should().HaveCount(1);
        inventory.Additional[0].Should().Be(additional);
    }

    [Fact]
    public void EmptyInventory_GetCommonBonus_Zero()
    {
        var inventory = new Inventory();
        
        var bonus = inventory.GetCommonBonus();
        
        bonus.Should().Be(0);
    }
    
    [Fact]
    public void FullInventory_GetCommonBonus_AllPositionsCounted()
    {
        var inventory = new Inventory()
        {
            Head = new Smut(1, 100, "Smut"),
            Legs = new Shoes(2, 100, "Shoes"),
            Torso = new BulletproofVest(3, 100, "BulletproofVest"),
            LeftHand = new Weapon(4, 100, "Weapon"),
            RightHand = new Weapon(5, 100, "Weapon2"),
            Additional = {new Additional(6, 100, "Additional"), new Additional(7, 100, "Additional2")} 
        };
        
        var bonus = inventory.GetCommonBonus();
        
        bonus.Should().Be(inventory.Head.Bonus + inventory.Legs.Bonus + inventory.Torso.Bonus +
                          inventory.LeftHand.Bonus + inventory.RightHand.Bonus + inventory.Additional.Sum(x => x.Bonus));
    }
    
    [Fact]
    public void TwoHandsWeapon_GetCommonBonus_WeaponBonusNotDoubled()
    {
        var weapon = new Weapon(4, 100, "Weapon", handsAmount: 2);
        var inventory = new Inventory
        {
            Head = new Smut(1, 100, "Smut"),
            Legs = new Shoes(2, 100, "Shoes"),
            Torso = new BulletproofVest(3, 100, "BulletproofVest"),
            LeftHand = weapon,
            RightHand = weapon,
            Additional = {new Additional(5, 100, "Additional"), new Additional(6, 100, "Additional2")} 
        };
        
        var bonus = inventory.GetCommonBonus();
        
        bonus.Should().Be(inventory.Head.Bonus + inventory.Legs.Bonus + inventory.Torso.Bonus +
                          inventory.LeftHand.Bonus + inventory.Additional.Sum(x => x.Bonus));
    }

    [Fact]
    public void FillInventory_Clear_EmptyInventory()
    {
        var inventory = new Inventory
        {
            Head = new Smut(1, 100, "Smut"),
            Legs = new Shoes(1, 100, "Shoes"),
            Torso = new BulletproofVest(1, 100, "BulletproofVest"),
            LeftHand = new Weapon(1, 100, "Weapon"),
            RightHand = new Weapon(1, 100, "Weapon"),
            Additional = {new Additional(1, 100, "Additional")}
        };
        
        inventory.Clear();
        
        inventory.Head.Should().BeNull();
        inventory.Legs.Should().BeNull();
        inventory.Torso.Should().BeNull();
        inventory.LeftHand.Should().BeNull();
        inventory.RightHand.Should().BeNull();
        inventory.Additional.Should().BeEmpty();
    }
}