using FluentAssertions;
using Manchkin.Core;
using Xunit;

namespace ManchkinCoreTests.PlayerTests;

public class PlayerTests
{
    private Random _random = new();

    [Fact]
    public void PlayerСreationTest()
    {
        var player = new Player(Sex.Female, Color.Orange, [new Smut(3, 100, "Головняк")]);
        
        player.Should().BeEquivalentTo(new
        {
            Sex = Sex.Female,
            Color = Color.Orange,
            Level = 1,
            Inventory = new Inventory(),
            Curses = new List<Curse>(),
            Cards = new List<Card>() {new Smut(3, 100, "Головняк")}
        });
    }
    
    [Fact]
    public void IncreaseLevelTest()
    {
        var player = GeneratePlayer();
        
        player.IncreaseLevel(2);
        
        player.Level.Should().Be(3);
    }

    [Fact]
    public void DecreaseFirstLevelTest()
    {
        var player = GeneratePlayer();
        
        player.DecreaseLevel(1);
        
        player.Level.Should().Be(1);
    }
    
    [Fact]
    public void DecreaseSecondLevelTest()
    {
        var player = GeneratePlayer();
        player.IncreaseLevel(1);
        
        player.DecreaseLevel(1);
        
        player.Level.Should().Be(1);
    }

    [Fact]
    public void RemoveCursesTest()
    {
        var player = GeneratePlayer();
        player.AddCurse(new CurseLevelLoss("Потеряй уровень", 1));
        
        player.RemoveCurses();
        
        player.Curses.Should().BeEmpty();
    }

    [Fact]
    public void AddCursesTest()
    {
        var curse = new CurseLevelLoss("Потеряй уровень", 1);
        var player = GeneratePlayer();
        
        player.AddCurse(curse);
        
        player.Curses.Should().HaveCount(1);
        player.Curses[0].Should().Be(curse);
    }    
    
    [Fact]
    public void DieTest()
    {
        var player = GeneratePlayer();
        player.Cards.Add(new Smut(3, 100, "Головняк"));
        player.Inventory.Head = new Smut(3, 100, "Головняк");
        player.Inventory.LeftHand = new Weapon(1, 100, "Оружие");
        player.Inventory.RightHand = new Weapon(2, 200, "Оружие2");
        player.Inventory.Legs = new Shoes(1, 100, "Обувка");
        player.Inventory.Torso = new BulletproofVest(3, 500, "Броник");
        player.Inventory.Additional.Add(new Additional(3, 200, "Титул"));
        player.IncreaseLevel(1);
        
        player.Die();
        
        player.Dead.Should().BeTrue();
        player.Cards.Should().BeEmpty();
        player.Inventory.Head.Should().BeNull();
        player.Inventory.LeftHand.Should().BeNull();
        player.Inventory.RightHand.Should().BeNull();
        player.Inventory.Legs.Should().BeNull();
        player.Inventory.Torso.Should().BeNull();
        player.Inventory.Additional.Should().BeEmpty();
        player.Level.Should().Be(2);
    }

    [Fact]
    public void FightingStrengthTest()
    {
        var player = GeneratePlayer();
        player.IncreaseLevel(1);
        player.Inventory.Head = new Smut(5, 100, "Головняк");
        player.FightingStrength.Should().Be(7);
    }

    private Player GeneratePlayer()
    {
        return new Player((Sex)_random.Next(0, 2), (Color)_random.Next(0, 6), []);
    }
    
}