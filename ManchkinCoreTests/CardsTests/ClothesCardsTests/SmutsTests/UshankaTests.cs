using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.SmutsTests;

public class UshankaTests
{
    private readonly Ushanka _ushanka = new();

    [Fact]
    public void UshankaCreated_GetTitle_TitleCorrect()
    {
        _ushanka.Title.Should().Be("Ушанка");
    }
    
    [Fact]
    public void UshankaCreated_GetPrice_PriceCorrect()
    {
        _ushanka.Price.Should().Be(400);
    }
    
    [Fact]
    public void UshankaCreated_GetWashBonus_WashBonusCorrect()
    {
        _ushanka.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void UshankaCreated_GetBonus_BonusCorrect()
    {
        _ushanka.Bonus.Should().Be(2);
    }
    
    [Fact]
    public void UshankaCreated_GetIsBigFlag_NotBig()
    {
        _ushanka.IsBig.Should().BeFalse();
    }
}