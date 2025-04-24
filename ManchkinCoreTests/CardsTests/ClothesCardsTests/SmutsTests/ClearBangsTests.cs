using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.SmutsTests;

public class ClearBangsTests
{
    private readonly ClearBangs _clearBangs = new();

    [Fact]
    public void ClearBangsCreated_GetTitle_TitleCorrect()
    {
        _clearBangs.Title.Should().Be("Чёткая чёлка");
    }
    
    [Fact]
    public void ClearBangsCreated_GetPrice_PriceCorrect()
    {
        _clearBangs.Price.Should().Be(200);
    }
    
    [Fact]
    public void ClearBangsCreated_GetWashBonus_WashBonusCorrect()
    {
        _clearBangs.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void ClearBangsCreated_GetBonus_BonusCorrect()
    {
        _clearBangs.Bonus.Should().Be(1);
    }
    
    [Fact]
    public void ClearBangsCreated_GetIsBigFlag_NotBig()
    {
        _clearBangs.IsBig.Should().BeFalse();
    }
}