using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using ManchkinCoreTests.PlayerTests;
using Xunit;

namespace ManchkinCoreTests.CardsTests.MonstersCardsTests;

public class IvanTheTerribleTests
{
    private readonly IvanTheTerrible _ivanTheTerrible = new();
    [Fact]
    public void IvanTheTerribleCreated_Punish_PlayerVestIsNull()
    {
        var player = new TestHelper().GenerateEmptyPlayer();
        player.Inventory.PutOn(new BigVest());
        
        _ivanTheTerrible.Punish(player);

        player.Inventory.Torso.Should().BeNull();
    }

    [Fact]
    public void IvanTheTerribleCreated_GetDescription_DescriptionCorrect()
    {
        _ivanTheTerrible.Description.Should().Be("При проигрыше потеря броника");
    }
    
    [Fact]
    public void IvanTheTerribleCreated_GetLevel_LevelCorrect()
    {
        _ivanTheTerrible.Level.Should().Be(2);
    }
    
    [Fact]
    public void IvanTheTerribleCreated_GetTitle_TitleCorrect()
    {
        _ivanTheTerrible.Title.Should().Be("Иван Грозный");
    }
    
    [Fact]
    public void IvanTheTerribleCreated_GetTreasuresCount_TreasuresCountCorrect()
    {
        _ivanTheTerrible.TreasuresCount.Should().Be(1);
    }
    
    [Fact]
    public void IvanTheTerribleCreated_GetLevelsCount_LevelsCountCorrect()
    {
        _ivanTheTerrible.LevelsCount.Should().Be(1);
    }
    
    [Fact]
    public void IvanTheTerribleCreated_GetDoesNotFightLevel_DoesNotFightLevelCorrect()
    {
        _ivanTheTerrible.DoesNotFightLevel.Should().Be(0);
    }
}