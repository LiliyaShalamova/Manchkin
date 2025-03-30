namespace Manchkin.Core.Game.States;

public class CommandResult<T>
{
    /// <summary>
    /// Доступна ли команда
    /// </summary>
    public bool IsAvailable { get; set; }
    
    /// <summary>
    /// Результат выполнения команды: Void, bool, Door
    /// </summary>
    public T? Result { get; set; }

    public CommandResult(bool isAvailable, T? result)
    {
        IsAvailable = isAvailable;
        Result = result;
    }
}

