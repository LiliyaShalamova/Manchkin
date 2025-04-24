using Manchkin.Core.Cards.Treasures.Clothes;

namespace ManchkinCoreTests.CardsForTest;

public class SmallTwoHandsWeapon : IWeapon
{
    public string Title => "Маленькое оружие в две руки";
    public int Price => 300;
    public int WashBonus => 0;
    public int Bonus => 2;
    public bool IsBig => false;
    public int HandsAmount => 2;
}