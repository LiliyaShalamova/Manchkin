namespace Manchkin.Core.Game.States;

public class CommandResult
{
    /// <summary>
    /// Доступна ли команда
    /// </summary>
    public bool IsAvailable { get; set; }

    public CommandResult(bool isAvailable)
    {
        IsAvailable = isAvailable;
    }
}

