using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.SmutsTests;

public class PointedHatOfPowerTests
{
    private readonly PointedHatOfPower _pointedHatOfPower = new();

    [Fact]
    public void PointedHatOfPowerCreated_GetTitle_TitleCorrect()
    {
        _pointedHatOfPower.Title.Should().Be("Остроконечная шляпа могущества");
    }
    
    [Fact]
    public void PointedHatOfPowerCreated_GetPrice_PriceCorrect()
    {
        _pointedHatOfPower.Price.Should().Be(400);
    }
    
    [Fact]
    public void PointedHatOfPowerCreated_GetWashBonus_WashBonusCorrect()
    {
        _pointedHatOfPower.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void PointedHatOfPowerCreated_GetBonus_BonusCorrect()
    {
        _pointedHatOfPower.Bonus.Should().Be(3);
    }
    
    [Fact]
    public void PointedHatOfPowerCreated_GetIsBigFlag_NotBig()
    {
        _pointedHatOfPower.IsBig.Should().BeFalse();
    }
}