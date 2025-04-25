using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using ManchkinCoreTests.PlayerTests;
using Xunit;

namespace ManchkinCoreTests.CardsTests.CursesCardsTests;

public class CurseShoesLossTests
{
    private readonly CurseShoesLoss _curseShoesLoss = new();

    [Fact]
    public void CurseShoesLossCreated_Curse_PlayerLegsIsNull()
    {
        var player = new TestHelper().GenerateEmptyPlayer();
        player.Inventory.Legs = new BigShoes();
        
        _curseShoesLoss.Curse(player);

        player.Inventory.Legs.Should().BeNull();
    }

    [Fact]
    public void CurseShoesLossCreated_GetTitle_TitleCorrect()
    {
        _curseShoesLoss.Title.Should().Be("Цемент не схватился! Потеряй надетую обувку!");
    }
    
    [Fact]
    public void CurseShoesLossCreated_GetOneTimeCurseFlag_OneTimeCurse()
    {
        _curseShoesLoss.OneTimeCurse.Should().BeTrue();
    }
}