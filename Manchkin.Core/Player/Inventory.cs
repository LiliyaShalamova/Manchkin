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
    public List<Clothes>? Additional { get; set; }
    
    public int GetCommonBonus()
    {
        return (Head?.Bonus ?? 0) + (LeftHand?.Bonus ?? 0) + (RightHand?.Bonus ?? 0) + 
               (Torso?.Bonus ?? 0) + (Legs?.Bonus ?? 0) + (Additional?.Sum(clothes => clothes.Bonus) ?? 0);
    }
}