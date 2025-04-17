using Manchkin.Core.Cards.Treasures.Clothes;

namespace ManchkinCoreTests.PlayerTests;

public class BigTwoHandWeapon : IWeapon
{
    public string Title => "Большое оружие в две руки";
    public int Price => 300;
    public int WashBonus => 0;
    public int Bonus => 2;
    public bool IsBig => true;
    public int HandsAmount => 2;
}