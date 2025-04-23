using Manchkin.Core.Cards.Treasures.Clothes;

namespace ManchkinCoreTests.PlayerTests;

public class BigShoes : IShoes
{
    public string Title => "Большая обувка";
    public int Price => 300;
    public int WashBonus => 3;
    public int Bonus => 3;
    public bool IsBig => true;
}