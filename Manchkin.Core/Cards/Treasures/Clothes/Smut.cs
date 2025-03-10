namespace Manchkin.Core;

/// <summary>
/// Головняк
/// </summary>
public class Smut : Clothes
{
    public Smut(int bonus, int price, string title, bool isBig = false, int wash = 0) : base(bonus, price, title, isBig)
    {
    }
}