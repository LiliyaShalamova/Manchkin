using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Xunit;

namespace ManchkinCoreTests.CardsTests.CursesCardsTests;

public class CutOffTheBranchLevelLossCurseTests
{
    private readonly CutOffTheBranchLevelLossCurse _cutOffTheBranchLevelLossCurse = new();

    [Fact]
    public void CutOffTheBranchLevelLossCurseCreated_Curse_PlayerLevelDecreased()
    {
        var player = new TestHelper().GenerateEmptyPlayer();
        player.IncreaseLevel(5);
        var levelBeforePunish = player.Level;
        
        _cutOffTheBranchLevelLossCurse.Curse(player);

        player.Level.Should().Be(levelBeforePunish - _cutOffTheBranchLevelLossCurse.LevelLossCount);
    }

    [Fact]
    public void CutOffTheBranchLevelLossCurseCreated_GetTitle_TitleCorrect()
    {
        _cutOffTheBranchLevelLossCurse.Title.Should().Be("Сруби сук, на котором сидишь! Потеряй уровень");
    }
    
    [Fact]
    public void CutOffTheBranchLevelLossCurseCreated_GetOneTimeCurseFlag_OneTimeCurse()
    {
        _cutOffTheBranchLevelLossCurse.OneTimeCurse.Should().BeTrue();
    }
    
    [Fact]
    public void CutOffTheBranchLevelLossCurseCreated_GetLevelLossCount_LevelLossCountCorrect()
    {
        _cutOffTheBranchLevelLossCurse.LevelLossCount.Should().Be(1);
    }
}