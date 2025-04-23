using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Xunit;

namespace ManchkinCoreTests.CardsTests.MonstersCardsTests;

public class BabaYagaTests
{
    private readonly BabaYaga _babaYaga = new BabaYaga();
    [Fact]
    public void BabaYagaCreated_Punish_PlayerLevelDecreased()
    {
        var player = new TestHelper().GeneratePlayer();
        player.IncreaseLevel(5);
        var levelBeforePunish = player.Level;
        
        _babaYaga.Punish(player);

        player.Level.Should().Be(levelBeforePunish - _babaYaga.LevelLossCount);
    }

    [Fact]
    public void BabaYagaCreated_GetDescription_DescriptionCorrect()
    {
        _babaYaga.Description.Should().Be($"При проигрыше потеря уровней {_babaYaga.LevelLossCount}");
    }
    
    [Fact]
    public void BabaYagaCreated_GetLevel_LevelCorrect()
    {
        _babaYaga.Level.Should().Be(18);
    }
    
    [Fact]
    public void BabaYagaCreated_GetTitle_TitleCorrect()
    {
        _babaYaga.Title.Should().Be("Баба Яга");
    }
    
    [Fact]
    public void BabaYagaCreated_GetTreasuresCount_TreasuresCountCorrect()
    {
        _babaYaga.TreasuresCount.Should().Be(4);
    }
    
    [Fact]
    public void BabaYagaCreated_GetLevelsCount_LevelsCountCorrect()
    {
        _babaYaga.LevelsCount.Should().Be(2);
    }
    
    [Fact]
    public void BabaYagaCreated_GetDoesNotFightLevel_DoesNotFightLevelCorrect()
    {
        _babaYaga.DoesNotFightLevel.Should().Be(3);
    }
}