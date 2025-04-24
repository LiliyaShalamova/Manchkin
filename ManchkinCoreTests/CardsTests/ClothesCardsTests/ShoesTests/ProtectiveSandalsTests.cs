using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.ShoesTests;

public class ProtectiveSandalsTests
{
    private readonly ProtectiveSandals _protectiveSandals = new();

    [Fact]
    public void ProtectiveSandalsCreated_GetTitle_TitleCorrect()
    {
        _protectiveSandals.Title.Should().Be("Сандалеты-протекторы");
    }
    
    [Fact]
    public void ProtectiveSandalsCreated_GetPrice_PriceCorrect()
    {
        _protectiveSandals.Price.Should().Be(700);
    }
    
    [Fact]
    public void ProtectiveSandalsCreated_GetWashBonus_WashBonusCorrect()
    {
        _protectiveSandals.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void ProtectiveSandalsCreated_GetBonus_BonusCorrect()
    {
        _protectiveSandals.Bonus.Should().Be(0);
    }
    
    [Fact]
    public void ProtectiveSandalsCreated_GetIsBigFlag_NotBig()
    {
        _protectiveSandals.IsBig.Should().BeFalse();
    }
}