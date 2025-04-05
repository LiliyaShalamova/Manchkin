namespace Manchkin.Core.Cards.Doors;

/// <summary>
/// Класс игрока
/// </summary>
public class PlayerClass : IDoor
{
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; init; }

    /// <summary>
    /// Равенство сил в бою
    /// </summary>
    public bool ForcesEquality { get; }
}