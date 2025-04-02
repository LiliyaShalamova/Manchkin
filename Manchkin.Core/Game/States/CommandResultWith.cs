namespace Manchkin.Core.Game.States;

public class CommandResultWith<T> : CommandResult
{
    /// <summary>
    /// Результат выполнения команды: bool, Door
    /// </summary>
    public T? Result { get; set; }
    
    public CommandResultWith(bool isAvailable, T? result) : base(isAvailable)
    {
        IsAvailable = isAvailable;
        Result = result;
    }
}