using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.AdditionalClothesTests;

public class TrulyImpressiveTitleTests
{
    private readonly TrulyImpressiveTitle _trulyImpressiveTitle = new();

    [Fact]
    public void TrulyImpressiveTitleCreated_GetTitle_TitleCorrect()
    {
        _trulyImpressiveTitle.Title.Should().Be("Реально впечатляющий титул");
    }
    
    [Fact]
    public void TrulyImpressiveTitleCreated_GetPrice_PriceCorrect()
    {
        _trulyImpressiveTitle.Price.Should().Be(0);
    }
    
    [Fact]
    public void TrulyImpressiveTitleCreated_GetWashBonus_WashBonusCorrect()
    {
        _trulyImpressiveTitle.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void TrulyImpressiveTitleCreated_GetBonus_BonusCorrect()
    {
        _trulyImpressiveTitle.Bonus.Should().Be(3);
    }
    
    [Fact]
    public void TrulyImpressiveTitleCreated_GetIsBigFlag_NotBig()
    {
        _trulyImpressiveTitle.IsBig.Should().BeFalse();
    }
}