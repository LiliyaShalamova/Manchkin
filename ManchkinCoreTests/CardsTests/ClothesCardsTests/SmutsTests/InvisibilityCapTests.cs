using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.SmutsTests;

public class InvisibilityCapTests
{
    private readonly InvisibilityCap _invisibilityCap = new();

    [Fact]
    public void InvisibilityCapCreated_GetTitle_TitleCorrect()
    {
        _invisibilityCap.Title.Should().Be("Шапка-невидимка");
    }
    
    [Fact]
    public void InvisibilityCapCreated_GetPrice_PriceCorrect()
    {
        _invisibilityCap.Price.Should().Be(300);
    }
    
    [Fact]
    public void InvisibilityCapCreated_GetWashBonus_WashBonusCorrect()
    {
        _invisibilityCap.WashBonus.Should().Be(1);
    }
    
    [Fact]
    public void InvisibilityCapCreated_GetBonus_BonusCorrect()
    {
        _invisibilityCap.Bonus.Should().Be(1);
    }
    
    [Fact]
    public void InvisibilityCapCreated_GetIsBigFlag_NotBig()
    {
        _invisibilityCap.IsBig.Should().BeFalse();
    }
}