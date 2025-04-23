using Manchkin.Core.Cards.Treasures.Clothes;

namespace ManchkinCoreTests.PlayerTests;

public class BigSmut : ISmut
{
    public string Title => "Большой головняк";
    public int Price => 100;
    public int WashBonus => 0;
    public int Bonus => 2;
    public bool IsBig => true;
}