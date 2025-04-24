using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.SmutsTests;

public class UkokoshnikTests
{
    private readonly Ukokoshnik _ukokoshnik = new();

    [Fact]
    public void UkokoshnikCreated_GetTitle_TitleCorrect()
    {
        _ukokoshnik.Title.Should().Be("Укокошник");
    }
    
    [Fact]
    public void UkokoshnikCreated_GetPrice_PriceCorrect()
    {
        _ukokoshnik.Price.Should().Be(600);
    }
    
    [Fact]
    public void UkokoshnikCreated_GetWashBonus_WashBonusCorrect()
    {
        _ukokoshnik.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void UkokoshnikCreated_GetBonus_BonusCorrect()
    {
        _ukokoshnik.Bonus.Should().Be(3);
    }
    
    [Fact]
    public void UkokoshnikCreated_GetIsBigFlag_NotBig()
    {
        _ukokoshnik.IsBig.Should().BeFalse();
    }
}