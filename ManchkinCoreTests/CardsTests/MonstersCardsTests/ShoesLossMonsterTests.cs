using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using ManchkinCoreTests.PlayerTests;
using Xunit;

namespace ManchkinCoreTests.CardsTests.MonstersCardsTests;

public class ShoesLossMonsterTests
{
    private readonly ShoesLossMonster _shoesLossMonster = new();
    [Fact]
    public void ShoesLossMonsterCreated_Punish_PlayerShoesIsNull()
    {
        var player = new TestHelper().GeneratePlayer();
        player.Inventory.Legs = new BigShoes();
        
        _shoesLossMonster.Punish(player);

        player.Inventory.Legs.Should().BeNull();
    }

    [Fact]
    public void ShoesLossMonsterCreated_GetDescription_DescriptionCorrect()
    {
        _shoesLossMonster.Description.Should().Be("При проигрыше потеря обувки");
    }
    
    [Fact]
    public void ShoesLossMonsterCreated_GetLevel_LevelCorrect()
    {
        _shoesLossMonster.Level.Should().Be(3);
    }
    
    [Fact]
    public void ShoesLossMonsterCreated_GetTitle_TitleCorrect()
    {
        _shoesLossMonster.Title.Should().Be("Обувная моль");
    }
    
    [Fact]
    public void ShoesLossMonsterCreated_GetTreasuresCount_TreasuresCountCorrect()
    {
        _shoesLossMonster.TreasuresCount.Should().Be(1);
    }
    
    [Fact]
    public void ShoesLossMonsterCreated_GetLevelsCount_LevelsCountCorrect()
    {
        _shoesLossMonster.LevelsCount.Should().Be(1);
    }
    
    [Fact]
    public void ShoesLossMonsterCreated_GetDoesNotFightLevel_DoesNotFightLevelCorrect()
    {
        _shoesLossMonster.DoesNotFightLevel.Should().Be(0);
    }
}