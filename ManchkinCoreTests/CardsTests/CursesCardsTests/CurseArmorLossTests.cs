using FluentAssertions;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using ManchkinCoreTests.PlayerTests;
using Xunit;

namespace ManchkinCoreTests.CardsTests.CursesCardsTests;

public class CurseArmorLossTests
{
    private readonly CurseArmorLoss _curseArmorLoss = new();
    private readonly TestHelper _testHelper = new();

    [Fact]
    public void CurseArmorLossCreated_Curse_PlayerTorsoIsNull()
    {
        var player = _testHelper.GeneratePlayer();
        player.Inventory.Torso = new BigVest();
        
        _curseArmorLoss.Curse(player);
        
        player.Inventory.Torso.Should().BeNull();
    }

    [Fact]
    public void CurseArmorLossCreated_GetTitle_TitleCorrect()
    {
        _curseArmorLoss.Title.Should().Be("Генномодифицированная моль! Потеряй надетый броник");
    }
    
    [Fact]
    public void CurseArmorLossCreated_GetOneTimeCurseFlag_OneTimeCurse()
    {
        _curseArmorLoss.OneTimeCurse.Should().BeTrue();
    }
}