namespace Manchkin.Core;

/// <summary>
/// Инвентарь игрока
/// </summary>
public class Inventory
{
    /// <summary>
    /// Голова
    /// </summary>
    public Clothes? Head { get; set; }
    
    /// <summary>
    /// Левая рука
    /// </summary>
    public Clothes? LeftHand { get; set; }
    
    /// <summary>
    /// Правая рука
    /// </summary>
    public Clothes? RightHand { get; set; }
    
    /// <summary>
    /// Торс
    /// </summary>
    public Clothes? Torso  { get; set; }
    
    /// <summary>
    /// Ноги
    /// </summary>
    public Clothes? Legs{ get; set; }
    
    /// <summary>
    /// Дополнительные вещи, например, титул
    /// </summary>
    public Clothes[]? Additional { get; set; }
    
    public int GetCommonBonus()
    {
        return (Head?.Bonus ?? 0) + (LeftHand?.Bonus ?? 0) + (RightHand?.Bonus ?? 0) + 
               (Torso?.Bonus ?? 0) + (Legs?.Bonus ?? 0) + (Additional?.Sum(clothes => clothes.Bonus) ?? 0);
    }
}