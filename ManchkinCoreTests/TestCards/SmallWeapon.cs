using Manchkin.Core.Cards.Treasures.Clothes;

namespace ManchkinCoreTests.PlayerTests;

public class SmallWeapon : IWeapon
{
    public string Title => "Маленькое оружие";
    public int Price => 100;
    public int WashBonus => 0;
    public int Bonus => 1;
    public bool IsBig => false;
    public int HandsAmount => 1;
}