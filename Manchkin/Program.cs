// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using Manchkin.Core;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Extensions;

namespace Manchkin;

//TODO добавить в командах, что если игрок мертв, надо снова выдать 8 карт

public static class Program
{
    private static readonly Dictionary<Command, Action<Game, Player, string[], bool>> Commands;

    static Program()
    {
        Commands = new Dictionary<Command, Action<Game, Player, string[], bool>>()
        {
            { Command.PutOn, ExecuteCommandPutOn },
            { Command.Drop, ExecuteCommandDrop },
            { Command.Sell, ExecuteCommandSell },
            { Command.Curse, ExecuteCommandCurse },
            { Command.Next, ExecuteCommandNext },
            { Command.Cast, ExecuteCommandCast },
            { Command.Door, ExecuteCommandDoor },
            { Command.Monster, ExecuteCommandMonster},
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
            PrintPlayerInfo(player);
            ExecuteCommand(game, player, i == game.Players.Length - 1);
        }
    }

    private static void PhaseTwo(Game game)
    {
        Console.WriteLine("Фаза 2. Игра");
        while (!game.IsGameOver())
        {
            for (var i = 0; i < game.Players.Length; i++)
            {
                var player = game.Players[i];
                Console.WriteLine($"Игрок {player.Color}, ваш ход");
                PrintPlayerInfo(player);
                ExecuteCommand(game, player, i == game.Players.Length - 1);
            }
        }
    }

    private static void ExecuteCommand(Game game, Player player, bool lastPlayer)
    {
        while (true)
        {
            var allowedCommands = PrintAllowedCommands(game);
            string command;
            if ((command = Console.ReadLine()!) == "Next" && game.GameProcessor.State.Next(player, lastPlayer))
            {
                break;
            }

            var commandArray = command.Split(" ");
            var commandName = commandArray[0];
            switch (commandName)
            {
                case "PutOn" when allowedCommands.Contains(commandName):
                    if (!ExecuteByCommand(Command.PutOn, game, player, commandArray, lastPlayer))
                    {
                        continue;
                    }
                    PrintPlayerInfo(player);
                    continue;

                case "Drop" when allowedCommands.Contains(commandName):
                    if (!ExecuteByCommand(Command.Drop, game, player, commandArray, lastPlayer))
                    {
                        continue;
                    }
                    PrintPlayerInfo(player);
                    continue;

                case "Sell" when allowedCommands.Contains(commandName):
                    if (!ExecuteByCommand(Command.Sell, game, player, commandArray, lastPlayer))
                    {
                        continue;
                    }
                    PrintPlayerInfo(player);
                    continue;

                case "Next" when allowedCommands.Contains(commandName):
                    ExecuteByCommand(Command.Next, game, player, commandArray, lastPlayer);
                    continue;

                case "Curse" when allowedCommands.Contains(commandName):
                    ExecuteCommandCurse(game, player, commandArray, lastPlayer);
                    PrintPlayerInfo(player);
                    continue;

                case "Cast" when allowedCommands.Contains(commandName):
                    ExecuteByCommand(Command.Cast, game, player, commandArray, lastPlayer);
                    continue;

                case "Door" when allowedCommands.Contains(commandName):
                    ExecuteByCommand(Command.Door, game, player, commandArray, lastPlayer);
                    continue;

                case "GetAway" when allowedCommands.Contains(commandName):
                    if (game.GameProcessor.State.GetAway(player))
                    {
                        Console.WriteLine("Удалось смыться от монстра!");
                    }
                    else
                    {
                        Console.WriteLine("Не удалось смыться. Получи наказание");
                    }
                    return;

                case "Monster" when allowedCommands.Contains(commandName):
                    ExecuteByCommand(Command.Monster, game, player, commandArray, lastPlayer);
                    continue;
                case "Fight" when allowedCommands.Contains(commandName):
                    ExecuteByCommand(Command.Fight, game, player, commandArray, lastPlayer);
                    continue;
                default:
                    Console.WriteLine("Недоступная команда.");
                    continue;
            }
            break;
        }
    }

    private static bool ExecuteByCommand(Command command, Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
        try
        {
            Commands[command](game, player, commandsArray, lastPlayer);
            return true;
        }
        catch (Exception)
        {
            Console.WriteLine("Неправильно заданы параметры команды");
            return false;
        }
    }
    
    private static void CheckCardsCount(Game game, Player player, bool lastPlayer)
    {
        ExecuteCommand(game, player, lastPlayer);
    }
    
    private static void ExecuteCommandPutOn(Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
        var clothes = commandsArray
            .Skip(1)
            .Select(str => (Clothes)player.Cards[int.Parse(str) - 1])
            .ToArray();
        game.GameProcessor.State.PutOn(player, clothes);
    }

    private static void ExecuteCommandDrop(Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
        var cards = commandsArray
            .Skip(1)
            .Select(str => player.Cards[int.Parse(str) - 1])
            .ToArray();
        game.GameProcessor.State.Drop(player, cards);
    }

    private static void ExecuteCommandSell(Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
        var treasures = commandsArray
            .Skip(1)
            .Select(str => (Treasure)player.Cards[int.Parse(str) - 1])
            .ToArray();
        if (!game.GameProcessor.State.Sell(player, treasures))
        {
            Console.WriteLine("Недостаточно карт для продажи. Сумма карт должна быть не менее 1000");
        }
    }

    private static void ExecuteCommandCurse(Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
        var to = game.Players
            .FirstOrDefault(p => p.Color.ToString() == commandsArray[1]) ?? throw new InvalidOperationException();
        var curse = player.Cards[int.Parse(commandsArray[2]) - 1] as ICurse ?? throw new InvalidOperationException();
        game.GameProcessor.State.Curse(player, to, curse);
    }

    private static void ExecuteCommandNext(Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
        if (!game.GameProcessor.State.Next(player, lastPlayer))
        {
            Console.WriteLine("У вас на руках больше 5 карт.");
        }
    }

    private static void ExecuteCommandCast(Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
        var spell = player.Cards[int.Parse(commandsArray[1]) - 1] as Spell;
        var isSpellCasted = game.GameProcessor.State.Cast(player, spell);
        if (!isSpellCasted)
        {
            Console.WriteLine("Не удалось наложить заклинание.");
        }
        else
        {
            PrintPlayerInfo(player);
        }
    }

    private static void ExecuteCommandDoor(Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
            var door = game.GameProcessor.State.Door(player);
            door.Print();
    }

    private static void ExecuteCommandMonster(Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
        var monster = (Monster)player.Cards[int.Parse(commandsArray[1]) - 1];
        monster.Print();
        game.GameProcessor.State.Monster(player, monster);

    }

    private static void ExecuteCommandFight(Game game, Player player, string[] commandsArray, bool lastPlayer)
    {
        if (!game.GameProcessor.State.Fight(player))
        {
            Console.WriteLine("Не хватает боевой силы для победы.");
        }
        else
        {
            Console.WriteLine("Победа!");
            PrintPlayerInfo(player);
            CheckCardsCount(game, player, lastPlayer); //если стало > 5
        }
    }
    
    private static void PrintCards(Player player)
    {
        Console.WriteLine($"Игрок {player.Color}, ваши карты:");
        for (var i = 1; i <= player.Cards.Count; i++)
        {
            Console.Write($"№ {i} ");
            player.Cards[i - 1].Print();
        }

        Console.WriteLine();
        Console.WriteLine("На руках должно быть не более 5 карт");
    }

    private static void PrintInventory(Player player)
    {
        var inventory = player.Inventory;
        Console.WriteLine("Инвентарь");
        Console.WriteLine($"Общий бонус: {inventory.GetCommonBonus()}");
        inventory.Head?.Print();
        inventory.Torso?.Print();
        inventory.LeftHand?.Print();
        inventory.RightHand?.Print();
        inventory.Legs?.Print();
        inventory.Additional?.ForEach(card => card.Print());
    }

    private static void PrintPlayerInfo(Player player)
    {
        Console.WriteLine($"Игрок {player.Color}: уровень {player.Level}");
        Console.WriteLine();
        PrintInventory(player);
        Console.WriteLine();
        PrintCards(player);
        Console.WriteLine();
    }

    private static List<string> PrintAllowedCommands(Game game)
    {
        var allowedCommands = game.GameProcessor.State.GetAllowCommands()
            .Select(c => c.ToString())
            .ToList();
        Console.WriteLine($"Список доступных команд: {string.Join(", ", allowedCommands)}");
        return allowedCommands;
    }
}