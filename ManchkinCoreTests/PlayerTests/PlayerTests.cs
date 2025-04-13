using AutoFixture;
using FluentAssertions;
using Manchkin.Core;
using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;
using Manchkin.Core.Player;
using Xunit;

namespace ManchkinCoreTests.PlayerTests;

// TODO использовать autofixture в тестах obsolete и протянуть везде конструкторы
public class PlayerTests
{/*
    private Fixture _fixture = new();
    
    private readonly Random _random = new();

    [Fact]
    public void ValidData_CreatePlayer_InitializedCorrectly()
    {
        //var player = _fixture.Create<Player>();
        var player = new Player(Sex.Female, Color.Orange, [new Ukokoshnik(3, 100, "Головняк")]);
        
        player.Should().BeEquivalentTo(new
        {
            Sex = Sex.Female,
            Color = Color.Orange,
            Level = 1,
            Inventory = new Inventory(),
            Curses = new List<Curse>(),
            Cards = new List<Card>() {new Ukokoshnik(3, 100, "Головняк")}
        });
    }
    
    [Fact]
    public void PlayerCreated_IncreaseLevel_LevelIncreased()
    {
        var player = GeneratePlayer();
        
        player.IncreaseLevel(2);
        
        player.Level.Should().Be(3);
    }

    [Fact]
    public void FirstLevelPlayerCreated_DecreaseLevel_LevelNotIncreased()
    {
        var player = GeneratePlayer();
        
        player.DecreaseLevel(1);
        
        player.Level.Should().Be(1);
    }
    
    [Fact]
    public void SeconsLevelPlayerCreated_DecreaseLevel_LevelDecreased()
    {
        var player = GeneratePlayer();
        player.IncreaseLevel(1);
        
        player.DecreaseLevel(1);
        
        player.Level.Should().Be(1);
    }

    [Fact]
    public void PlayerWithCurses_RemoveCurses_CursesRemoved()
    {
        var player = GeneratePlayer();
        player.AddCurse(new PaintedLevelLossCurse("Потеряй уровень", 1));
        
        player.RemoveCurses();
        
        player.Curses.Should().BeEmpty();
    }

    [Fact]
    public void PlayerWithoutCurses_AddCurses_CursesAdded()
    {
        var curse = new PaintedLevelLossCurse("Потеряй уровень", 1);
        var player = GeneratePlayer();
        
        player.AddCurse(curse);
        
        player.Curses.Should().HaveCount(1);
        player.Curses[0].Should().Be(curse);
    }    
    
    [Fact]
    public void PlayerAlive_Die_PlayerDead()
    {
        var player = GeneratePlayer();
        player.Cards.Add(new Ukokoshnik(3, 100, "Головняк"));
        player.Inventory.Head = new Ukokoshnik(3, 100, "Головняк");
        player.Inventory.LeftHand = new SwordLollipop(1, 100, "Оружие");
        player.Inventory.RightHand = new SwordLollipop(2, 200, "Оружие2");
        player.Inventory.Legs = new DesignerShoes(1, 100, "Обувка");
        player.Inventory.Torso = new MithrilArmor(3, 500, "Броник");
        player.Inventory.Additional.Add(new TrulyImpressiveTitle(3, 200, "Титул"));
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
    public void PlayerCreated_GetFightingStrength_FightingStrengthCorrect()
    {
        var player = GeneratePlayer();
        player.IncreaseLevel(1);
        player.Inventory.Head = new Ukokoshnik(5, 100, "Головняк");
        player.FightingStrength.Should().Be(7);
    }

    private Player GeneratePlayer()
    {
        return new Player((Sex)_random.Next(0, 2), (Color)_random.Next(0, 6), []);
    }
    */
}