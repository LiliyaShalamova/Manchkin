using FluentAssertions;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Xunit;

namespace ManchkinCoreTests.CardsTests.ClothesCardsTests.ShoesTests;

public class DesignerShoesTests
{
    private readonly DesignerShoes _designerShoes = new();

    [Fact]
    public void DesignerShoesCreated_GetTitle_TitleCorrect()
    {
        _designerShoes.Title.Should().Be("Дизайнерские лапти");
    }
    
    [Fact]
    public void DesignerShoesCreated_GetPrice_PriceCorrect()
    {
        _designerShoes.Price.Should().Be(700);
    }
    
    [Fact]
    public void DesignerShoesCreated_GetWashBonus_WashBonusCorrect()
    {
        _designerShoes.WashBonus.Should().Be(0);
    }
    
    [Fact]
    public void DesignerShoesCreated_GetBonus_BonusCorrect()
    {
        _designerShoes.Bonus.Should().Be(4);
    }
    
    [Fact]
    public void DesignerShoesCreated_GetIsBigFlag_NotBig()
    {
        _designerShoes.IsBig.Should().BeFalse();
    }
}