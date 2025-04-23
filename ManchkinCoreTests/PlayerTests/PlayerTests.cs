using AutoFixture;
using FluentAssertions;
using Manchkin.Core;
using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;
using Manchkin.Core.Players;
using Xunit;

namespace ManchkinCoreTests.PlayerTests;

// TODO использовать autofixture в тестах obsolete и протянуть везде конструкторы
public class PlayerTests
{
    private readonly TestHelper _testHelper = new();
    [Fact]
    public void ValidData_CreatePlayer_InitializedCorrectly()
    {
        //var player = _fixture.Create<Player>();
        var player = new Player(Sex.Female, Color.Orange, [new Ukokoshnik()]);
        
        player.Should().BeEquivalentTo(new
        {
            Sex = Sex.Female,
            Color = Color.Orange,
            Level = 1,
            Inventory = new Inventory(),
            Curses = new List<ICurse>(),
            Cards = new List<ICard>() {new Ukokoshnik()}
        });
    }
    
    [Fact]
    public void PlayerCreated_IncreaseLevel_LevelIncreased()
    {
        var player = _testHelper.GeneratePlayer();
        
        player.IncreaseLevel(2);
        
        player.Level.Should().Be(3);
    }

    [Fact]
    public void FirstLevelPlayerCreated_DecreaseLevel_LevelNotIncreased()
    {
        var player = _testHelper.GeneratePlayer();
        
        player.DecreaseLevel(1);
        
        player.Level.Should().Be(1);
    }
    
    [Fact]
    public void SecondLevelPlayerCreated_DecreaseLevel_LevelDecreased()
    {
        var player = _testHelper.GeneratePlayer();
        player.IncreaseLevel(1);
        
        player.DecreaseLevel(1);
        
        player.Level.Should().Be(1);
    }

    [Fact]
    public void PlayerWithCurses_RemoveCurses_CursesRemoved()
    {
        var player = _testHelper.GeneratePlayer();
        player.AddCurse(new PaintedLevelLossCurse());
        
        player.RemoveCurses();
        
        player.Curses.Should().BeEmpty();
    }

    [Fact]
    public void PlayerWithoutCurses_AddCurses_CursesAdded()
    {
        var curse = new PaintedLevelLossCurse();
        var player = _testHelper.GeneratePlayer();
        
        player.AddCurse(curse);
        
        player.Curses.Should().HaveCount(1);
        player.Curses[0].Should().Be(curse);
    }    
    
    [Fact]
    public void PlayerAlive_Die_PlayerDead()
    {
        var player = _testHelper.GeneratePlayer();
        player.Cards = player.Cards.Add(new Ukokoshnik());
        player.Inventory.Head = new Ukokoshnik();
        player.Inventory.LeftHand = new SwordLollipop();
        player.Inventory.RightHand = new BathBroom();
        player.Inventory.Legs = new DesignerShoes();
        player.Inventory.Torso = new MithrilArmor();
        player.Inventory.Additional = player.Inventory.Additional.Add(new TrulyImpressiveTitle());
        player.IncreaseLevel(1);
        
        player.Die();
        
        player.IsDead.Should().BeTrue();
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
        var smut = new Ukokoshnik();
        var player = _testHelper.GeneratePlayer();
        player.IncreaseLevel(1);
        player.Inventory.Head = smut;
        
        player.FightingStrength.Should().Be(smut.Bonus + 2);
    }
}