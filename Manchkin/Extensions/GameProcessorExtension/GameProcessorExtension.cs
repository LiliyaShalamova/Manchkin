using Manchkin.Core;
using Manchkin.Core.Game;

namespace Manchkin.Extensions.GameProcessorExtension;

public static class GameProcessorExtension
{
    public static List<Command> PrintAllowedCommands(this Game game)
    {
        var allowedCommands = game.GetAllowCommands();
        Console.WriteLine($"Список доступных команд: {string.Join(", ", allowedCommands)}");
        return allowedCommands;
    }
}