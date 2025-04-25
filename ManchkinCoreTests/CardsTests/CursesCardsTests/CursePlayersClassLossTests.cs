using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Xunit;

namespace ManchkinCoreTests.CardsTests.CursesCardsTests;

public class CursePlayersClassLossTests
{
    private readonly CursePlayersClassLoss _cursePlayersClassLoss = new();

    [Fact]
    public void CursePlayersClassLossCreated_Curse_PlayersClassIsNull()
    {
        var player = new TestHelper().GenerateEmptyPlayer();
        
        _cursePlayersClassLoss.Curse(player);

        player.MainClass.Should().BeNull();
    }

    [Fact]
    public void CursePlayersClassLossCreated_GetTitle_TitleCorrect()
    {
        _cursePlayersClassLoss.Title.Should().Be("Инфляция! Потеряй класс!");
    }
    
    [Fact]
    public void CursePlayersClassLossCreated_GetOneTimeCurseFlag_OneTimeCurse()
    {
        _cursePlayersClassLoss.OneTimeCurse.Should().BeTrue();
    }
}