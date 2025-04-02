using Manchkin.Core;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cube;
using Manchkin.Core.Game;
using Manchkin.Core.Player;
using Manchkin.Extensions;
using Manchkin.Extensions.GameProcessorExtension;
using Manchkin.Extensions.PlayerExtension;

namespace Manchkin;

//TODO добавить в командах, что если игрок мертв, надо снова выдать 8 карт
// TODO сделать возможность передачи своих карточек из Console *
// TODO убрать приведение типов в Core, оставить только в Program DONE
// TODO убрать дублирование Game в методах DONE

public static class Program
{
    private static readonly Dictionary<Command, Action<string[]>> Commands;
    private static Game _game;

    static Program()
    {
        Commands = new Dictionary<Command, Action<string[]>>
        {
            { Command.Dress, ExecuteCommandDress },
            { Command.Drop, ExecuteCommandDrop },
            { Command.Sell, ExecuteCommandSell },
            { Command.Curse, ExecuteCommandCurse },
            { Command.Finish, ExecuteCommandFinish },
            { Command.Cast, ExecuteCommandCast },
            { Command.Door, ExecuteCommandDoor },
            { Command.Monster, ExecuteCommandMonster },
            { Command.Fight, ExecuteCommandFight },
            { Command.Run, ExecuteCommandRun }
        };
    }

    public static void Main(string[] args)
    {
        var gameConfig = new GameConfig { PlayersCount = ReadPlayersCount() };
        _game = new Game(gameConfig);
        Start();
    }

    private static int ReadPlayersCount()
    {
        int playersCount; // TODO вынести получение количества в отдельный метод DONE
        Console.WriteLine("Введите количество игроков для начала игры");
        while (!int.TryParse(Console.ReadLine(), out playersCount))
        {
            Console.WriteLine("Некорректно задано количество игроков");
            Console.WriteLine("Введите количество игроков для начала игры");
        }

        return playersCount;
    }
    
    private static void Start() // TODO переименовать в Start DONE
    {
        _game.GetCurrentPlayer().Print();
        while (!_game.IsGameOver())
        {
            var allowedCommands = _game.PrintAllowedCommands();
            var command = Console.ReadLine();
            var args = command?.Split(" ") ?? [];
            if (args.Length > 0 && Enum.TryParse(args[0], true, out Command commandName)) //TODO разбить if DONE
            {
                if (allowedCommands.Contains(commandName))
                {
                    Commands[commandName](args);
                }
                else
                {
                    Console.WriteLine("Недоступная команда");
                }
            }
            else
            {
                Console.WriteLine("Недоступная команда");
            }
        }
    }

    private static void ExecuteCommandDress(string[] args)
    {
        var clothes = ParseArgs<Clothes>(args);
        if (clothes.Length == 0)
        {
            return;
        }
        _game.Dress(clothes);
        _game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandDrop(string[] args)
    {
        var cards = ParseArgs<Card>(args);
        if (cards.Length == 0)
        {
            return;
        }
        _game.Drop(cards);
        _game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandSell(string[] args)
    {
        var treasures = ParseArgs<Treasure>(args);
        if (treasures.Length == 0)
        {
            return;
        }
        var result = _game.Sell(treasures);
        if (!result.Result)
        {
            Console.WriteLine("Недостаточно карт для продажи. Сумма карт должна быть не менее 1000");
        }
        else
        {
            _game.GetCurrentPlayer().Print();
        }
    }

    private static void ExecuteCommandCurse(string[] args)
    {
        var currentPlayer = _game.GetCurrentPlayer();
        var isCorrectPlayerArg = args.Length == 3 && _game.GetPlayerByColor(args[1]) != null;
        
        var isNumericCardIndex = int.TryParse(args[2], out var cardIndex);
        var isExistingIndex = cardIndex >= 1 && cardIndex <= currentPlayer.Cards.Count;
        var isCurseCard = cardIndex > 0 && currentPlayer.Cards[cardIndex - 1] is ICurse;
        var isCorrectCurseArgs = isNumericCardIndex && isExistingIndex && isCurseCard;
        
        if (!(isCorrectPlayerArg && isCorrectCurseArgs))//TODO разбить большой if DONE
        {
            Console.WriteLine("Неправильно заданы параметры команды");
            return;
        }
        var to = _game.GetPlayerByColor(args[1]); // TODO сделать в Game метод получения игрока по цвету DONE
        var curse = (ICurse)_game.GetCurrentPlayer().Cards[int.Parse(args[2]) - 1];
        _game.Curse(to!, curse);
        Console.WriteLine($"Игрок {to!.Color}, на тебя наложено проклятие");
    }

    private static void ExecuteCommandFinish(string[] args)
    {
        var result = _game.Finish();
        if (!result.Result)
        {
            Console.WriteLine("У вас на руках больше 5 карт.");
        }
        else
        {
            _game.GetCurrentPlayer().Print();
        }
    }

    private static void ExecuteCommandCast(string[] args)
    {
        var spells = ParseArgs<Spell>(args);
        if (spells.Length == 0)
        {
            return;
        }
        var result = _game.Cast(spells[0]);
        if (!result.Result)
        {
            Console.WriteLine("Не удалось наложить заклинание.");
        }
        else
        {
            _game.GetCurrentPlayer().Print();
        }
    }

    private static void ExecuteCommandDoor(string[] args)
    {
        var result = _game.PullDoor();
        result.Result!.Print();
        _game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandMonster(string[] args)
    {
        var monsters = ParseArgs<Monster>(args); // TODO проверять, что аргумент ровно 1 DONE
        if (monsters.Length == 0 || monsters.Length > 1)
        {
            return;
        }
        monsters[0].Print();
        _game.Monster(monsters[0]);
        _game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandFight(string[] args)
    {
        var result = _game.Fight();
        if (!result.Result)
        {
            Console.WriteLine("Вы проиграли");
        }
        else
        {
            Console.WriteLine("Победа!");
            _game.GetCurrentPlayer().Print();
        }
    }

    private static void ExecuteCommandRun(string[] args)
    {
        var result = _game.Run();
        Console.WriteLine(result.Result ? "Удалось смыться от монстра!" : "Не удалось смыться. Получи наказание");
        _game.GetCurrentPlayer().Print();
    }

    private static T[] ParseArgs<T>(string[] command) where T : Card // TODO не получать в аргументах Game. Получать только то что нужно (массив карт) DONE
    {
        var args = command.Skip(1).ToArray();
        var cards = _game.GetCurrentPlayer().Cards; // TODO сделать чтобы int.Parse вызывался только один раз для каждого элемента DONE
        var cardsToReturn = new T[args.Length];
        if (args.Length == 0)
        {
            Console.WriteLine("Неправильно заданы параметры команды");
            return [];
        }

        for (var i = 0; i < args.Length; i++)
        {
            var isNumericIndex = int.TryParse(args[i], out var cardIndex);// TODO разбить и проверять на 0 и отрицательные числа DONE
            var isExistingIndex = cardIndex >= 1 && cardIndex <= cards.Count;
            var cardIsTypeOfT = cardIndex > 0 && cards[cardIndex - 1] is T;
            if (isNumericIndex && isExistingIndex && cardIsTypeOfT)
            {
                cardsToReturn[i] = (T)cards[cardIndex - 1];
            }
            else
            {
                Console.WriteLine("Неправильно заданы параметры команды");
                return [];
            }
        }
        
        return cardsToReturn;
    }
}