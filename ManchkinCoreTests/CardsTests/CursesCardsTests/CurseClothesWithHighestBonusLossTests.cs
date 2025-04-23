using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using ManchkinCoreTests.PlayerTests;
using Xunit;

namespace ManchkinCoreTests.CardsTests.CursesCardsTests;

public class CurseClothesWithHighestBonusLossTests
{
    private readonly CurseClothesWithHighestBonusLoss _curseClothesWithHighestBonusLoss = new();
    private readonly TestHelper _testHelper = new();
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_GetTitle_TitleCorrect()
    {
        _curseClothesWithHighestBonusLoss.Title.Should().Be("Сдаём на подарки! Потеряй шмотку с наибольшим бонусом");
    }
    
    [Fact]
    public void CurseClothesWithHighestBonusLossCreated_GetOneTimeCurseFlag_OneTimeCurse()
    {
        _curseClothesWithHighestBonusLoss.OneTimeCurse.Should().BeTrue();
    }
}