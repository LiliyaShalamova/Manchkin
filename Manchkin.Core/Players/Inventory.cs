using System.Collections.Immutable;
using Manchkin.Core.Cards.Treasures.Clothes;

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
    public ImmutableList<IAdditional>? Additional { get; internal set; } = [];

    internal Inventory()
    {
    }
    
    internal Inventory(ISmut? head = null, IWeapon? leftHand = null, IWeapon? rightHand = null, IVest? torso = null,
        IShoes? legs = null, ImmutableList<IAdditional>? additional = null)
    {
        Head = head;
        LeftHand = leftHand;
        RightHand = rightHand;
        Torso = torso;
        Legs = legs;
        Additional = additional;
    }
    
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
        if (clothes.IsBig)
        {
            CheckBigClothes(clothesToReturn);
        }
        
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
                Additional = Additional.Add(additional);
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

    private void CheckBigClothes(List<IClothes> clothesToReturn)
    {
        if (Head is { IsBig: true })
        {
            clothesToReturn.Add(Head);
            Head = null;
            return;
        }

        if (Torso is { IsBig: true })
        {
            clothesToReturn.Add(Torso);
            Torso = null;
            return;
        }

        if (Legs is { IsBig: true })
        {
            clothesToReturn.Add(Legs);
            Legs = null;
            return;
        }

        if (LeftHand is { IsBig: true })
        {
            clothesToReturn.Add(LeftHand);
            if (LeftHand.HandsAmount == 2)
            {
                RightHand = null;
            }
            LeftHand = null;
            return;
        }

        if (RightHand is { IsBig: true })
        {
            clothesToReturn.Add(RightHand);
            RightHand = null;
            return;
        }
        Additional.ForEach(add =>
        {
            if (add.IsBig)
            {
                clothesToReturn.Add(add);
                Additional = Additional.Remove(add);
            }
        });
    }

    internal void Clear()
    {
        Head = null;
        LeftHand = null;
        RightHand = null;
        Torso = null;
        Legs = null;
        Additional = Additional.Clear();
    }
}