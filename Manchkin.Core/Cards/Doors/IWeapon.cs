using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;

namespace Manchkin.Core.Cards.Doors;

public interface IWeapon : IClothes
{
    int HandsAmount { get; }
}