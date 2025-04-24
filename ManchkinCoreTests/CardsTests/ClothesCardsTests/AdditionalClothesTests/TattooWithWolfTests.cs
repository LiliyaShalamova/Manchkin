using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.AdditionalClothesTests;

public class TattooWithWolfTests
{
    private readonly TattooWithWolf _tattooWithWolf = new();

    [Fact]
    public void TattooWithWolfCreated_GetTitle_TitleCorrect()
    {
        _tattooWithWolf.Title.Should().Be("Татуировка с волком");
    }
    
    [Fact]
    public void TattooWithWolfCreated_GetPrice_PriceCorrect()
    {
        _tattooWithWolf.Price.Should().Be(600);
    }
    
    [Fact]
    public void TattooWithWolfCreated_GetWashBonus_WashBonusCorrect()
    {
        _tattooWithWolf.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void TattooWithWolfCreated_GetBonus_BonusCorrect()
    {
        _tattooWithWolf.Bonus.Should().Be(2);
    }
    
    [Fact]
    public void TattooWithWolfCreated_GetIsBigFlag_NotBig()
    {
        _tattooWithWolf.IsBig.Should().BeFalse();
    }
}