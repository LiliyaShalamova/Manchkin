using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using ManchkinCoreTests.PlayerTests;
using Xunit;

namespace ManchkinCoreTests.CardsTests.CursesCardsTests;

public class PaintedLevelLossCurseTests
{
    private readonly PaintedLevelLossCurse _paintedLevelLossCurse = new();

    [Fact]
    public void PaintedLevelLossCurseCreated_Curse_PlayerLevelDecreased()
    {
        var player = new TestHelper().GeneratePlayer();
        player.IncreaseLevel(5);
        var levelBeforePunish = player.Level;
        
        _paintedLevelLossCurse.Curse(player);

        player.Level.Should().Be(levelBeforePunish - _paintedLevelLossCurse.LevelLossCount);
    }

    [Fact]
    public void PaintedLevelLossCurseCreated_GetTitle_TitleCorrect()
    {
        _paintedLevelLossCurse.Title.Should().Be("Окрашено! Потеряй уровень!");
    }
    
    [Fact]
    public void PaintedLevelLossCurseCreated_GetOneTimeCurseFlag_OneTimeCurse()
    {
        _paintedLevelLossCurse.OneTimeCurse.Should().BeTrue();
    }
    
    [Fact]
    public void PaintedLevelLossCurseCreated_GetLevelLossCount_LevelLossCountCorrect()
    {
        _paintedLevelLossCurse.LevelLossCount.Should().Be(1);
    }
}