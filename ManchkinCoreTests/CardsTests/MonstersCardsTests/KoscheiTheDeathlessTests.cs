using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Xunit;

namespace ManchkinCoreTests.CardsTests.MonstersCardsTests;

public class KoscheiTheDeathlessTests
{
    private readonly KoscheiTheDeathless _koscheiTheDeathless = new();
    [Fact]
    public void KoscheiTheDeathlessCreated_Punish_PlayerDied()
    {
        var player = new TestHelper().GeneratePlayer();
        
        _koscheiTheDeathless.Punish(player);

        player.IsDead.Should().BeTrue();
    }

    [Fact]
    public void KoscheiTheDeathlessCreated_GetDescription_DescriptionCorrect()
    {
        _koscheiTheDeathless.Description.Should().Be("При проигрыше смерть");
    }
    
    [Fact]
    public void KoscheiTheDeathlessCreated_GetLevel_LevelCorrect()
    {
        _koscheiTheDeathless.Level.Should().Be(18);
    }
    
    [Fact]
    public void KoscheiTheDeathlessCreated_GetTitle_TitleCorrect()
    {
        _koscheiTheDeathless.Title.Should().Be("Кощей Бессмертный");
    }
    
    [Fact]
    public void KoscheiTheDeathlessCreated_GetTreasuresCount_TreasuresCountCorrect()
    {
        _koscheiTheDeathless.TreasuresCount.Should().Be(5);
    }
    
    [Fact]
    public void KoscheiTheDeathlessCreated_GetLevelsCount_LevelsCountCorrect()
    {
        _koscheiTheDeathless.LevelsCount.Should().Be(2);
    }
    
    [Fact]
    public void KoscheiTheDeathlessCreated_GetDoesNotFightLevel_DoesNotFightLevelCorrect()
    {
        _koscheiTheDeathless.DoesNotFightLevel.Should().Be(4);
    }
}