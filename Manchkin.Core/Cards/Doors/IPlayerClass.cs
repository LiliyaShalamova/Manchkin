namespace Manchkin.Core.Cards.Doors;

/// <summary>
/// Класс игрока
/// </summary>
public interface IPlayerClass : IDoor
{
    /// <summary>
    /// Название
    /// </summary>
    string Title { get; init; }

    /// <summary>
    /// Равенство сил в бою
    /// </summary>
    bool ForcesEquality { get; }
}