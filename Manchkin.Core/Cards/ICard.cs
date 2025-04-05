namespace Manchkin.Core.Cards;

/// <summary>
/// Карта
/// </summary>
public interface ICard
{
    /// <summary>
    /// Название
    /// </summary>
    public string Title { get; protected init; }
}