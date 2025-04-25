using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using ManchkinCoreTests.PlayerTests;
using Xunit;

namespace ManchkinCoreTests.CardsTests.MonstersCardsTests;

public class ViyTests
{
    private readonly Viy _viy = new();
    [Fact]
    public void ViyCreated_Punish_PlayerLevelDecreased()
    {
        var player = new TestHelper().GenerateEmptyPlayer();
        player.IncreaseLevel(5);
        var levelBeforePunish = player.Level;
        
        _viy.Punish(player);

        player.Level.Should().Be(levelBeforePunish - _viy.LevelLossCount);
    }

    [Fact]
    public void ViyCreated_GetDescription_DescriptionCorrect()
    {
        _viy.Description.Should().Be($"При проигрыше потеря уровней {_viy.LevelLossCount}");
    }
    
    [Fact]
    public void ViyCreated_GetLevel_LevelCorrect()
    {
        _viy.Level.Should().Be(6);
    }
    
    [Fact]
    public void ViyCreated_GetTitle_TitleCorrect()
    {
        _viy.Title.Should().Be("Вий");
    }
    
    [Fact]
    public void ViyCreated_GetTreasuresCount_TreasuresCountCorrect()
    {
        _viy.TreasuresCount.Should().Be(2);
    }
    
    [Fact]
    public void ViyCreated_GetLevelsCount_LevelsCountCorrect()
    {
        _viy.LevelsCount.Should().Be(1);
    }
    
    [Fact]
    public void ViyCreated_GetDoesNotFightLevel_DoesNotFightLevelCorrect()
    {
        _viy.DoesNotFightLevel.Should().Be(0);
    }
}