using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;

namespace Manchkin.Core.Player;

/// <summary>
/// Инвентарь игрока
/// </summary>
public class Inventory
{
    /// <summary>
    /// Голова
    /// </summary>
    public Ukokoshnik? Head { get; internal set; }

    /// <summary>
    /// Левая рука
    /// </summary>
    public SwordLollipop? LeftHand { get; internal set; }

    /// <summary>
    /// Правая рука
    /// </summary>
    public SwordLollipop? RightHand { get; internal set; }

    /// <summary>
    /// Торс
    /// </summary>
    public MithrilArmor? Torso { get; internal set; }

    /// <summary>
    /// Ноги
    /// </summary>
    public DesignerShoes? Legs { get; internal set; }

    /// <summary>
    /// Дополнительные вещи, например, титул
    /// </summary>
    public List<TrulyImpressiveTitle> Additional { get; internal set; } = [];

    // TODO Добавить обработку большой шмотки, большая может быть только одна
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
            case Ukokoshnik smut:
                if (Head != null)
                {
                    clothesToReturn.Add(Head);
                }
                Head = smut;
                break;
            case DesignerShoes shoes:
                if (Legs != null)
                {
                    clothesToReturn.Add(Legs);
                }
                Legs = shoes;
                break;
            case MithrilArmor vest:
                if (Torso != null)
                {
                    clothesToReturn.Add(Torso);
                }
                Torso = vest;
                break;
            case SwordLollipop weapon:
                PutOnWeapon(weapon, clothesToReturn);
                break;
            case TrulyImpressiveTitle additional:
                Additional.Add(additional);
                break;
        }

        return clothesToReturn;
    }

    private void PutOnWeapon(SwordLollipop swordLollipop, List<IClothes> clothesToReturn)
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
            LeftHand = swordLollipop;
            if (swordLollipop.HandsAmount == 2)
            {
                if (RightHand != null)
                {
                    clothesToReturn.Add(RightHand);
                }
                RightHand = swordLollipop;
            }
        }
        else
        {
            if (RightHand != null)
            {
                clothesToReturn.Add(RightHand);
            }
            RightHand = swordLollipop;
            if (swordLollipop.HandsAmount == 2)
            {
                if (LeftHand != null)
                {
                    clothesToReturn.Add(LeftHand);
                }
                LeftHand = swordLollipop;
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