using Manchkin.Core.Cards.Treasures.Clothes;

namespace ManchkinCoreTests.PlayerTests;

public class BigAdditionalClothes : IAdditional
{
    public string Title => "Большой титул";
    public int Price => 400;
    public int WashBonus => 1;
    public int Bonus => 4;
    public bool IsBig => true;
}