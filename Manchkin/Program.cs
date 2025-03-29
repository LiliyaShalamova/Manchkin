using Manchkin.Core;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Extensions;
using Manchkin.Extensions.GameProcessorExtension;
using Manchkin.Extensions.PlayerExtension;

namespace Manchkin;

//TODO добавить в командах, что если игрок мертв, надо снова выдать 8 карт
// TOOD хранить текущего игрока в GameProcessor. lastPlayer тоже 
// TODO сделать возможность передачи своих карточек из Console *

public static class Program
{
    private static readonly Dictionary<Command, Action<Game, string[]>> Commands;

    static Program()
    {
        Commands = new Dictionary<Command, Action<Game, string[]>>()
        {
            { Command.PutOn, ExecuteCommandPutOn },
            { Command.Drop, ExecuteCommandDrop },
            { Command.Sell, ExecuteCommandSell },
            { Command.Curse, ExecuteCommandCurse },
            { Command.Next, ExecuteCommandNext },
            { Command.Cast, ExecuteCommandCast },
            { Command.Door, ExecuteCommandDoor },
            { Command.Monster, ExecuteCommandMonster },
            { Command.Fight, ExecuteCommandFight }
        };
    }

    public static void Main(string[] args)
    {
        int playersCount;
        Console.WriteLine("Введите количество игроков для начала игры");
        while (!int.TryParse(Console.ReadLine() ?? throw new InvalidOperationException(), out playersCount))
        {
            Console.WriteLine("Некорректно задано количество игроков");
            Console.WriteLine("Введите количество игроков для начала игры");
        }

        var gameConfig = new GameConfig { PlayersCount = playersCount };
        var game = new Game(gameConfig, new MyCube());
        PhaseOne(game);
        PhaseTwo(game);
    }

    private static void PhaseOne(Game game)
    {
        Console.WriteLine("Фаза 1. Сброс карт");
        for (var i = 0; i < game.Players.Length; i++)
        {
            var player = game.Players[i];
            player.Print();
            ExecuteCommand(game);
        }
    }

    private static void PhaseTwo(Game game)
    {
        Console.WriteLine("Фаза 2. Игра");
        ExecuteCommand(game);
        /*while (!game.IsGameOver())
        {
            for (var i = 0; i < game.Players.Length; i++)
            {
                var player = game.Players[i];
                Console.WriteLine($"Игрок {player.Color}, ваш ход");
                PrintPlayerInfo(player);
                ExecuteCommand(game, player);
            }
        }*/
    }

    private static void ExecuteCommand(Game game)
    {
        while (!game.IsGameOver()) // TODO удалить switch case
        {
            var allowedCommands = game.GameProcessor.PrintAllowedCommands();
            string command;
            if ((command = Console.ReadLine()!) == "Next" && game.GameProcessor.CurrentState.Next())
            {
                break;
            }

            var commandArray = command.Split(" ");
            var commandName = commandArray[0];
            switch (commandName)
            {
                case "PutOn" when allowedCommands.Contains(commandName):
                    if (!ExecuteByCommand(Command.PutOn, game, commandArray))
                    {
                        continue;
                    }

                    game.GameProcessor.CurrentPlayer.Print();
                    continue;

                case "Drop" when allowedCommands.Contains(commandName):
                    if (!ExecuteByCommand(Command.Drop, game, commandArray))
                    {
                        continue;
                    }

                    game.GameProcessor.CurrentPlayer.Print();
                    continue;

                case "Sell" when allowedCommands.Contains(commandName):
                    if (!ExecuteByCommand(Command.Sell, game, commandArray))
                    {
                        continue;
                    }

                    game.GameProcessor.CurrentPlayer.Print();
                    continue;

                case "Next" when allowedCommands.Contains(commandName): // TODO назвать finish
                    ExecuteByCommand(Command.Next, game, commandArray);
                    continue;

                case "Curse" when allowedCommands.Contains(commandName):
                    ExecuteCommandCurse(game, commandArray);
                    game.GameProcessor.CurrentPlayer.Print();
                    continue;

                case "Cast" when allowedCommands.Contains(commandName):
                    ExecuteByCommand(Command.Cast, game, commandArray);
                    continue;

                case "Door" when allowedCommands.Contains(commandName):
                    ExecuteByCommand(Command.Door, game, commandArray);
                    continue;

                case "GetAway" when allowedCommands.Contains(commandName):
                    if (game.GameProcessor.CurrentState.GetAway())
                    {
                        Console.WriteLine("Удалось смыться от монстра!");
                    }
                    else
                    {
                        Console.WriteLine("Не удалось смыться. Получи наказание");
                    }

                    return;

                case "Monster" when allowedCommands.Contains(commandName):
                    ExecuteByCommand(Command.Monster, game, commandArray);
                    continue;
                case "Fight" when allowedCommands.Contains(commandName):
                    ExecuteByCommand(Command.Fight, game, commandArray);
                    continue;
                default:
                    Console.WriteLine("Недоступная команда.");
                    continue;
            }
        }
    }

    private static bool ExecuteByCommand(Command command, Game game, string[] commandsArray)
    {
        try
        {
            Commands[command](game, commandsArray);
            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("Неправильно заданы параметры команды");
            return false;
        }
    }

    private static void CheckCardsCount(Game game)
    {
        ExecuteCommand(game);
    }

    private static void ExecuteCommandPutOn(Game game, string[] commandsArray)
    {
        var clothes = commandsArray
            .Skip(1)
            .Select(str => (Clothes)game.GameProcessor.CurrentPlayer.Cards[int.Parse(str) - 1])
            .ToArray();
        game.GameProcessor.CurrentState.PutOn(clothes);
    }

    private static void ExecuteCommandDrop(Game game, string[] commandsArray)
    {
        var cards = commandsArray
            .Skip(1)
            .Select(str => game.GameProcessor.CurrentPlayer.Cards[int.Parse(str) - 1])
            .ToArray();
        game.GameProcessor.CurrentState.Drop(cards);
    }

    private static void ExecuteCommandSell(Game game, string[] commandsArray)
    {
        var treasures = commandsArray
            .Skip(1)
            .Select(str => (Treasure)game.GameProcessor.CurrentPlayer.Cards[int.Parse(str) - 1])
            .ToArray(); // TODO повторяющийся код вынести в отдельный метод
        if (!game.GameProcessor.CurrentState.Sell(treasures))
        {
            Console.WriteLine("Недостаточно карт для продажи. Сумма карт должна быть не менее 1000");
        }
    }

    private static void ExecuteCommandCurse(Game game, string[] commandsArray)
    {
        var to = game.Players
            .FirstOrDefault(p => p.Color.ToString() == commandsArray[1]) ?? throw new InvalidOperationException();
        var curse = game.GameProcessor.CurrentPlayer.Cards[int.Parse(commandsArray[2]) - 1] as ICurse ??
                    throw new InvalidOperationException(); // TODO везде убрать то что не понимаешь
        game.GameProcessor.CurrentState.Curse(to, curse);
    }

    private static void ExecuteCommandNext(Game game, string[] commandsArray)
    {
        if (!game.GameProcessor.CurrentState.Next())
        {
            Console.WriteLine("У вас на руках больше 5 карт.");
        }
    }

    private static void ExecuteCommandCast(Game game, string[] commandsArray)
    {
        var spell = game.GameProcessor.CurrentPlayer.Cards[int.Parse(commandsArray[1]) - 1] as Spell;
        var isSpellCasted = game.GameProcessor.CurrentState.Cast(spell);
        if (!isSpellCasted)
        {
            Console.WriteLine("Не удалось наложить заклинание.");
        }
        else
        {
            game.GameProcessor.CurrentPlayer.Print();
        }
    }

    private static void ExecuteCommandDoor(Game game, string[] commandsArray)
    {
        var door = game.GameProcessor.CurrentState.Door();
        door.Print();
    }

    private static void ExecuteCommandMonster(Game game, string[] commandsArray)
    {
        var monster = (Monster)game.GameProcessor.CurrentPlayer.Cards[int.Parse(commandsArray[1]) - 1];
        monster.Print();
        game.GameProcessor.CurrentState.Monster(monster);
    }

    private static void ExecuteCommandFight(Game game, string[] commandsArray)
    {
        if (!game.GameProcessor.CurrentState.Fight())
        {
            Console.WriteLine("Не хватает боевой силы для победы.");
        }
        else
        {
            Console.WriteLine("Победа!");
            game.GameProcessor.CurrentPlayer.Print();
            CheckCardsCount(game); //если стало > 5
        }
    }
}