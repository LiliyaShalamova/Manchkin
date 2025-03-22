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
    public BulletproofVest? Torso  { get; set; }
    
    /// <summary>
    /// Ноги
    /// </summary>
    public Shoes? Legs{ get; set; }

    /// <summary>
    /// Дополнительные вещи, например, титул
    /// </summary>
    public List<Clothes> Additional { get; set; } = [];// TODO убрать nullable done
    
    public int GetCommonBonus()
    {
        return (Head?.Bonus ?? 0) + (LeftHand?.Bonus ?? 0) + (RightHand?.Bonus ?? 0) + 
               (Torso?.Bonus ?? 0) + (Legs?.Bonus ?? 0) + (Additional?.Sum(clothes => clothes.Bonus) ?? 0);
    }

    public void PutOn(Clothes clothes)
    {
        switch (clothes)
                    {
                        case Smut smut:
                            Head = smut;
                            break;
                        case Shoes shoes:
                            Legs = shoes;
                            break;
                        case BulletproofVest vest:
                            Torso = vest;
                            break;
                        case Weapon weapon:
                        {
                            PutOnWeapon(weapon);
                            break;
                        }
                        case Clothes additional:
                            Additional.Add(additional);
                            break;
                    }
    }

    private void PutOnWeapon(Weapon weapon)
    {
        // TODO вынести в отдельный метод приватный done
        var toLeftHand = LeftHand == null || LeftHand != null && RightHand != null;
        if (toLeftHand) // TODO вынести в переменную done
        {
            LeftHand = weapon;
            if (weapon.HandsAmount == 2)
            {
                RightHand = weapon;
            }
        }
        else
        {
            RightHand = weapon;
            if (weapon.HandsAmount == 2)
            {
                LeftHand = weapon;
            }
        }
    }
}