namespace Manchkin.Core;

/// <summary>
/// Инвентарь игрока
/// </summary>
public class Inventory
{
    /// <summary>
    /// Голова
    /// </summary>
    public Smut? Head { get; set; }

    /// <summary>
    /// Левая рука
    /// </summary>
    public Weapon? LeftHand { get; set; }

    /// <summary>
    /// Правая рука
    /// </summary>
    public Weapon? RightHand { get; set; }

    /// <summary>
    /// Торс
    /// </summary>
    public BulletproofVest? Torso { get; set; }

    /// <summary>
    /// Ноги
    /// </summary>
    public Shoes? Legs { get; set; }

    /// <summary>
    /// Дополнительные вещи, например, титул
    /// </summary>
    public List<Additional> Additional { get; set; } = [];

    public int GetCommonBonus()
    {
        var bonus = (Head?.Bonus ?? 0) + (LeftHand?.Bonus ?? 0) + (RightHand?.Bonus ?? 0) +
                    (Torso?.Bonus ?? 0) + (Legs?.Bonus ?? 0) + Additional.Sum(clothes => clothes.Bonus);
        if (LeftHand is { IsBig: true })
        {
            bonus -= LeftHand.Bonus;
        }
        return bonus;
    }

    public List<Clothes> PutOn(Clothes clothes)
    {
        List<Clothes> clothesToReturn = [];
        switch (clothes)
        {
            case Smut smut:
                if (Head != null)
                {
                    clothesToReturn.Add(Head);
                }
                Head = smut;
                break;
            case Shoes shoes:
                if (Legs != null)
                {
                    clothesToReturn.Add(Legs);
                }
                Legs = shoes;
                break;
            case BulletproofVest vest:
                if (Torso != null)
                {
                    clothesToReturn.Add(Torso);
                }
                Torso = vest;
                break;
            case Weapon weapon:
                PutOnWeapon(weapon, clothesToReturn);
                break;
            case Additional additional:
                Additional.Add(additional); // TODO для additional создать свой класс DONE
                break;
        }

        return clothesToReturn;
    }

    private void PutOnWeapon(Weapon weapon, List<Clothes> clothesToReturn)
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
                LeftHand = weapon;
            }
        }
    }

    public void Clear()
    {
        Head = null;
        LeftHand = null;
        RightHand = null;
        Torso = null;
        Legs = null;
        Additional.Clear();
    }
}