using Manchkin.Core;

namespace Manchkin.Extensions.GameProcessorExtension;

public static class GameProcessorExtension
{
    public static List<string> PrintAllowedCommands(this GameProcessor gameProcessor)
    {
        var allowedCommands = gameProcessor.CurrentState.GetAllowCommands()
            .Select(c => c.ToString())
            .ToList();
        Console.WriteLine($"Список доступных команд: {string.Join(", ", allowedCommands)}");
        return allowedCommands;
    }
}