using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.ShoesTests;

public class FeltBootsTests
{
    private readonly FeltBoots _feltBoots = new();

    [Fact]
    public void FeltBootsCreated_GetTitle_TitleCorrect()
    {
        _feltBoots.Title.Should().Be("Валенки");
    }
    
    [Fact]
    public void FeltBootsCreated_GetPrice_PriceCorrect()
    {
        _feltBoots.Price.Should().Be(400);
    }
    
    [Fact]
    public void FeltBootsCreated_GetWashBonus_WashBonusCorrect()
    {
        _feltBoots.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void FeltBootsCreated_GetBonus_BonusCorrect()
    {
        _feltBoots.Bonus.Should().Be(3);
    }
    
    [Fact]
    public void FeltBootsCreated_GetIsBigFlag_NotBig()
    {
        _feltBoots.IsBig.Should().BeFalse();
    }
}