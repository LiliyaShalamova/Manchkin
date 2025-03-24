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
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество игроков для начала игры");
        int playersCount;
        try
        {
            playersCount = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            var gameConfig = new GameConfig { PlayersCount = playersCount };
            Console.WriteLine(Command.PutOn);
            var game = new Game(gameConfig);
            PhaseOne(game);
            PhaseTwo(game);
        }
        catch (Exception)
        {
            Console.WriteLine("Некорректно задано количество игроков");
        }
    }

    private static void PhaseOne(Game game)
    {
        Console.WriteLine("Фаза 1. Сброс карт");
        foreach (var player in game.Players)
        {
            PrintPlayerInfo(player);
            ExecuteCommand(game, player, 1);
        }
    }

    private static void PhaseTwo(Game game)
    {
        Console.WriteLine("Фаза 2. Игра");
        while (!game.IsGameOver())
        {
            foreach (var player in game.Players)
            {
                Console.WriteLine($"Игрок {player.Color}, ваш ход");
                PrintPlayerInfo(player);
                ExecuteCommand(game, player, 2);
            }
        }
    }

    private static void ExecuteCommand(Game game, Player player, int phase)
    {
        var moveNumber = 1;
        //PrintCommands(allowedCommands);
        string command;
        while (true)
        {
            var allowedCommands = game.GameProcessor.GetAllowCommands(phase, moveNumber)
                .Select(c => c.ToString())
                .ToList();
            PrintCommands(allowedCommands);
            if ((command = Console.ReadLine()!) == "Next" && game.GameProcessor.IsNextMoveAllowed(player))
            {
                break;
            }
            var commandArray = command.Split(" ");
            var commandName = commandArray[0];
            switch (commandName)
            {
                case "PutOn" when allowedCommands.Contains(commandName):
                    ExecuteCommandPutOn(game, player, commandArray);
                    PrintPlayerInfo(player);
                    //PrintCommands(allowedCommands);
                    continue;
                
                case "Drop" when allowedCommands.Contains(commandName):
                    ExecuteCommandDrop(game, player, commandArray);
                    PrintPlayerInfo(player);
                    //PrintCommands(allowedCommands);
                    continue;
                
                case "Sell" when allowedCommands.Contains(commandName):
                    ExecuteCommandSell(game, player, commandArray);
                    PrintPlayerInfo(player);
                    //PrintCommands(allowedCommands);
                    break;
                
                case "Next" when allowedCommands.Contains(commandName):
                    if (!game.GameProcessor.IsNextMoveAllowed(player))
                    {
                        Console.WriteLine("У вас на руках больше 5 карт.");
                        //PrintCommands(allowedCommands);
                    }
                    continue;
                
                case "Curse" when allowedCommands.Contains(commandName):
                    ExecuteCommandCurse(game, player, commandArray);
                    PrintPlayerInfo(player);
                    //PrintCommands(allowedCommands);
                    continue;
                
                case "Cast" when allowedCommands.Contains(commandName):
                    var spell = player.Cards[int.Parse(commandArray[1]) - 1] as Spell;
                    var isSpellCasted = game.GameProcessor.CastSpell(player, spell);
                    if (!isSpellCasted)
                    {
                        Console.WriteLine("Не удалось наложить заклинание.");
                    }
                    else
                    {
                        PrintPlayerInfo(player);
                    }
                    PrintCommands(allowedCommands);
                    continue;
                
                case "Door" when allowedCommands.Contains(commandName) && moveNumber == 1:
                    var door = game.GameProcessor.PullDoor();
                    door.Print();
                    switch (door)
                    {
                        case Monster monster:
                        {
                            if (!game.GameProcessor.Fight(player, monster))
                            {
                                Console.WriteLine("Не хватает боевой силы для победы.");
                                //allowedCommands = game.GameProcessor.GetAllowCommands(2, 1).Select(c => c.ToString()).ToList();
                                //PrintCommands(allowedCommands);
                                continue;
                            }

                            Console.WriteLine("Победа!");
                            PrintPlayerInfo(player);
                            //allowedCommands = game.GameProcessor.GetAllowCommands(1, 1).Select(c => c.ToString()).ToList();
                            //PrintCommands(allowedCommands);
                            break;
                        }

                        case Curse:
                            game.GameProcessor.Curse(player, player, (ICurse)door);
                            PrintPlayerInfo(player);
                            //allowedCommands = game.GameProcessor.GetAllowCommands(1, 1).Select(c => c.ToString()).ToList();
                            //PrintCommands(allowedCommands);
                            moveNumber = 2;
                            continue;
                    }
                    break;
                
                case "Door" when allowedCommands.Contains(commandName) && moveNumber == 2:
                    var d = game.GameProcessor.PullDoor();
                    d.Print();
                    player.Cards.Add(d);
                    break;

                case "GetAway" when allowedCommands.Contains(commandName):
                    if (game.GameProcessor.GetAway())
                    {
                        Console.WriteLine("Удалось смыться от монстра!");
                    }
                    else
                    {
                        Console.WriteLine("Не удалось смыться. Получи наказание");
                        game.GameProcessor.GetPunished();
                        allowedCommands = game.GameProcessor.GetAllowCommands(2, 1).Select(c => c.ToString())
                            .ToList();
                        PrintCommands(allowedCommands);
                    }
                    continue;
                
                case "Monster" when allowedCommands.Contains(commandName):
                    var m = (Monster)player.Cards[int.Parse(commandArray[1]) - 1];
                    m.Print();
                    if (!game.GameProcessor.Fight(player, m))
                    {
                        Console.WriteLine("Не хватает боевой силы для победы.");
                        //allowedCommands = game.GameProcessor.GetAllowCommands(2, 1).Select(c => c.ToString()).ToList();
                        //PrintCommands(allowedCommands);
                        continue;
                    }
                    Console.WriteLine("Победа!"); //TODO добавить обработку, что после открытия первой двери - монстра вторая дверь не тянется
                    PrintPlayerInfo(player);
                    break;
                default:
                    
                    Console.WriteLine("Недоступная команда.");
                    PrintCommands(allowedCommands);
                    break;
            }
            break;
        }
    }

    private static void ExecuteCommandPutOn(Game game, Player player, string[] commandArray)
    {
        var clothes = commandArray
            .Skip(1)
            .Select(str => (Clothes)player.Cards[int.Parse(str) - 1])
            .ToArray();
        game.GameProcessor.FillInventory(player, clothes);
    }

    private static void ExecuteCommandDrop(Game game, Player player, string[] commandArray)
    {
        var cards = commandArray
            .Skip(1)
            .Select(str => player.Cards[int.Parse(str) - 1])
            .ToArray();
        game.GameProcessor.ResetCards(player, cards);
    }
    
    private static void ExecuteCommandSell(Game game, Player player, string[] commandArray)
    {
        var treasures = commandArray
            .Skip(1)
            .Select(str => (Treasure)player.Cards[int.Parse(str) - 1])
            .ToArray();
        if (!game.GameProcessor.Sell(player, treasures))
        {
            Console.WriteLine("Недостаточно карт для продажи. Сумма карт должна быть не менее 1000");
        }
    }

    private static void ExecuteCommandCurse(Game game, Player player, string[] commandArray)
    {
        Player to;
        ICurse curse;
        try
        {
            to = game.Players
                .FirstOrDefault(p => p.Color.ToString() == commandArray[1]) ?? throw new InvalidOperationException();
            curse = player.Cards[int.Parse(commandArray[2]) - 1] as ICurse ?? throw new InvalidOperationException();
            game.GameProcessor.Curse(player, to, curse);
        }
        catch (Exception)
        {
            Console.WriteLine("Некорректно задан игрок и/или номер карты");
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
        Console.WriteLine($"Для начала игры необходимо иметь на руках не более 5 карт");
        //Console.WriteLine($"Доступные команды: надеть/продать/сбросить/проклятие/заклинание <№ карты>, далее");
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

    private static void PrintCommands(List<string> commands)
    {
        Console.WriteLine($"Список доступных команд: {String.Join(", ", commands)}");
    }
}