namespace Manchkin.Core.Cards.Doors;

public interface ICurse : IDoor
{
    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    bool OneTimeCurse { get; init; }

    void Curse(Players.Player player);
}