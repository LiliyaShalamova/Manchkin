using Manchkin.Core.Cards.Treasures.Clothes;

namespace ManchkinCoreTests.PlayerTests;

public class BigWeapon : IWeapon
{
    public string Title => "Большое оружие";
    public int Price => 500;
    public int WashBonus => 1;
    public int Bonus => 4;
    public bool IsBig => true;
    public int HandsAmount => 1;
}