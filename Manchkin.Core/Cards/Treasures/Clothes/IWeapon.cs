using Manchkin.Core.Players;

namespace Manchkin.Core.Cards.Treasures.Clothes;

public interface IWeapon : IClothes
{
    int HandsAmount { get; }
}