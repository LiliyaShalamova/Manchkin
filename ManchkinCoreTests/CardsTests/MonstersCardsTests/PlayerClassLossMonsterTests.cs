using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Xunit;

namespace ManchkinCoreTests.CardsTests.MonstersCardsTests;

public class PlayerClassLossMonsterTests
{
    private readonly PlayerClassLossMonster _playerClassLossMonster = new();
    [Fact]
    public void PlayerClassLossMonsterCreated_Punish_PlayerLevelDecreased()
    {
        var player = new TestHelper().GenerateEmptyPlayer();
        
        _playerClassLossMonster.Punish(player);

        player.MainClass.Should().BeNull();
    }

    [Fact]
    public void PlayerClassLossMonsterCreated_GetDescription_DescriptionCorrect()
    {
        _playerClassLossMonster.Description.Should().Be("При проигрыше потеря класса");
    }
    
    [Fact]
    public void PlayerClassLossMonsterCreated_GetLevel_LevelCorrect()
    {
        _playerClassLossMonster.Level.Should().Be(4);
    }
    
    [Fact]
    public void PlayerClassLossMonsterCreated_GetTitle_TitleCorrect()
    {
        _playerClassLossMonster.Title.Should().Be("Классный монстр");
    }
    
    [Fact]
    public void PlayerClassLossMonsterCreated_GetTreasuresCount_TreasuresCountCorrect()
    {
        _playerClassLossMonster.TreasuresCount.Should().Be(1);
    }
    
    [Fact]
    public void PlayerClassLossMonsterCreated_GetLevelsCount_LevelsCountCorrect()
    {
        _playerClassLossMonster.LevelsCount.Should().Be(1);
    }
    
    [Fact]
    public void PlayerClassLossMonsterCreated_GetDoesNotFightLevel_DoesNotFightLevelCorrect()
    {
        _playerClassLossMonster.DoesNotFightLevel.Should().Be(0);
    }
}