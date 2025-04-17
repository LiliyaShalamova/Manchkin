using Manchkin.Core.Cards.Treasures.Clothes;
using Moq.Language;

namespace ManchkinCoreTests.PlayerTests;

public class BigVest : IVest
{
    public string Title => "Большой броник";
    public int Price => 100;
    public int WashBonus => 1;
    public int Bonus => 1;
    public bool IsBig => true;
}