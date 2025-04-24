using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.ShoesTests;

public class ReallyFastRunningShoesTests
{
    private readonly ReallyFastRunningShoes _reallyFastRunningShoes = new();

    [Fact]
    public void ReallyFastRunningShoesCreated_GetTitle_TitleCorrect()
    {
        _reallyFastRunningShoes.Title.Should().Be("Башмаки реально быстрого бега");
    }
    
    [Fact]
    public void ReallyFastRunningShoesCreated_GetPrice_PriceCorrect()
    {
        _reallyFastRunningShoes.Price.Should().Be(400);
    }
    
    [Fact]
    public void ReallyFastRunningShoesCreated_GetWashBonus_WashBonusCorrect()
    {
        _reallyFastRunningShoes.WashBonus.Should().Be(2);
    }
    
    [Fact]
    public void ReallyFastRunningShoesCreated_GetBonus_BonusCorrect()
    {
        _reallyFastRunningShoes.Bonus.Should().Be(0);
    }
    
    [Fact]
    public void ReallyFastRunningShoesCreated_GetIsBigFlag_NotBig()
    {
        _reallyFastRunningShoes.IsBig.Should().BeFalse();
    }
}