namespace Manchkin.Core.Cards.Doors;

/// <summary>
/// Раса игрока
/// </summary>
public interface IRace : IDoor
{ 
    string Title { get; init; }
}