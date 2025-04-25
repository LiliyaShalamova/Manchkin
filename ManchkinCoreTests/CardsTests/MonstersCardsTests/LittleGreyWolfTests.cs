using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Xunit;

namespace ManchkinCoreTests.CardsTests.MonstersCardsTests;

public class LittleGreyWolfTests
{
    private readonly LittleGreyWolf _littleGreyWolf = new();
    [Fact]
    public void LittleGreyWolfCreated_Punish_PlayerLevelDecreased()
    {
        var player = new TestHelper().GenerateEmptyPlayer();
        player.IncreaseLevel(5);
        var levelBeforePunish = player.Level;
        
        _littleGreyWolf.Punish(player);

        player.Level.Should().Be(levelBeforePunish - _littleGreyWolf.LevelLossCount);
    }

    [Fact]
    public void LittleGreyWolfCreated_GetDescription_DescriptionCorrect()
    {
        _littleGreyWolf.Description.Should().Be($"При проигрыше потеря уровней {_littleGreyWolf.LevelLossCount}");
    }
    
    [Fact]
    public void LittleGreyWolfCreated_GetLevel_LevelCorrect()
    {
        _littleGreyWolf.Level.Should().Be(1);
    }
    
    [Fact]
    public void LittleGreyWolfCreated_GetTitle_TitleCorrect()
    {
        _littleGreyWolf.Title.Should().Be("Серенький волчок");
    }
    
    [Fact]
    public void LittleGreyWolfCreated_GetTreasuresCount_TreasuresCountCorrect()
    {
        _littleGreyWolf.TreasuresCount.Should().Be(1);
    }
    
    [Fact]
    public void LittleGreyWolfCreated_GetLevelsCount_LevelsCountCorrect()
    {
        _littleGreyWolf.LevelsCount.Should().Be(1);
    }
    
    [Fact]
    public void LittleGreyWolfCreated_GetDoesNotFightLevel_DoesNotFightLevelCorrect()
    {
        _littleGreyWolf.DoesNotFightLevel.Should().Be(0);
    }
}