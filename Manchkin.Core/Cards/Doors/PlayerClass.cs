namespace Manchkin.Core;

/// <summary>
/// Класс игрока
/// </summary>
public class PlayerClass : Door
{
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; }
    
    /// <summary>
    /// Равенство сил в боюь
    /// </summary>
    public bool ForcesEquality { get; }
    
}