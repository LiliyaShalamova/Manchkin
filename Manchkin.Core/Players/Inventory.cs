using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;

namespace Manchkin.Core.Players;

/// <summary>
/// Инвентарь игрока
/// </summary>
public class Inventory
{
    /// <summary>
    /// Голова
    /// </summary>
    public ISmut? Head { get; internal set; }

    /// <summary>
    /// Левая рука
    /// </summary>
    public IWeapon? LeftHand { get; internal set; }

    /// <summary>
    /// Правая рука
    /// </summary>
    public IWeapon? RightHand { get; internal set; }

    /// <summary>
    /// Торс
    /// </summary>
    public IVest? Torso { get; internal set; }

    /// <summary>
    /// Ноги
    /// </summary>
    public IShoes? Legs { get; internal set; }

    /// <summary>
    /// Дополнительные вещи, например, титул
    /// </summary>
    public List<IAdditional> Additional { get; internal set; } = [];
    
    public int GetCommonBonus()
    {
        var bonus = (Head?.Bonus ?? 0) + (LeftHand?.Bonus ?? 0) + (RightHand?.Bonus ?? 0) +
                    (Torso?.Bonus ?? 0) + (Legs?.Bonus ?? 0) + Additional.Sum(clothes => clothes.Bonus);
        if (LeftHand is { HandsAmount: 2 })
        {
            bonus -= LeftHand.Bonus;
        }
        return bonus;
    }

    internal List<IClothes> PutOn(IClothes clothes)
    {
        List<IClothes> clothesToReturn = [];
        switch (clothes)
        {
            case ISmut smut:
                if (Head != null)
                {
                    clothesToReturn.Add(Head);
                }
                Head = smut;
                break;
            case IShoes shoes:
                if (Legs != null)
                {
                    clothesToReturn.Add(Legs);
                }
                Legs = shoes;
                break;
            case IVest vest:
                if (Torso != null)
                {
                    clothesToReturn.Add(Torso);
                }
                Torso = vest;
                break;
            case IWeapon weapon:
                PutOnWeapon(weapon, clothesToReturn);
                break;
            case IAdditional additional:
                Additional.Add(additional);
                break;
        }

        return clothesToReturn;
    }

    private void PutOnWeapon(IWeapon weapon, List<IClothes> clothesToReturn)
    {
        var toLeftHand = LeftHand == null || LeftHand != null && RightHand != null;
        if (toLeftHand)
        {
            if (LeftHand != null)
            {
                clothesToReturn.Add(LeftHand);
            }

            if (LeftHand == RightHand)
            {
                RightHand = null;
            }
            LeftHand = weapon;
            if (weapon.HandsAmount == 2)
            {
                if (RightHand != null)
                {
                    clothesToReturn.Add(RightHand);
                }
                RightHand = weapon;
            }
        }
        else
        {
            if (RightHand != null)
            {
                clothesToReturn.Add(RightHand);
            }
            RightHand = weapon;
            if (weapon.HandsAmount == 2)
            {
                if (LeftHand != null)
                {
                    clothesToReturn.Add(LeftHand);
                }
                LeftHand = weapon;
            }
        }
    }

    internal void Clear()
    {
        Head = null;
        LeftHand = null;
        RightHand = null;
        Torso = null;
        Legs = null;
        Additional.Clear();
    }
}