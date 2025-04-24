using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.ShoesTests;

public class MightyKickBootsTests
{
    private readonly MightyKickBoots _mightyKickBoots = new();

    [Fact]
    public void MightyKickBootsCreated_GetTitle_TitleCorrect()
    {
        _mightyKickBoots.Title.Should().Be("Башмаки могучего пенделя");
    }
    
    [Fact]
    public void MightyKickBootsCreated_GetPrice_PriceCorrect()
    {
        _mightyKickBoots.Price.Should().Be(400);
    }
    
    [Fact]
    public void MightyKickBootsCreated_GetWashBonus_WashBonusCorrect()
    {
        _mightyKickBoots.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void MightyKickBootsCreated_GetBonus_BonusCorrect()
    {
        _mightyKickBoots.Bonus.Should().Be(2);
    }
    
    [Fact]
    public void MightyKickBootsCreated_GetIsBigFlag_NotBig()
    {
        _mightyKickBoots.IsBig.Should().BeFalse();
    }
}