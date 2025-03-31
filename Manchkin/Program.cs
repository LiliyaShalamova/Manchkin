using Manchkin.Core;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cube;
using Manchkin.Core.Game;
using Manchkin.Extensions;
using Manchkin.Extensions.GameProcessorExtension;
using Manchkin.Extensions.PlayerExtension;

namespace Manchkin;

//TODO добавить в командах, что если игрок мертв, надо снова выдать 8 карт
// TODO сделать возможность передачи своих карточек из Console *
// TODO максимально всё сокрыть (модификаторы доступа) DONE
// TODO убрать дублирование Game, переименовать в args DONE
// TODO удалить фазы DONE
// TODO избавиться от try catch DONE
// TODO Надо инкапсулировать всю механику. Пользователь не должен ничего знать про внутреннюю реализацию Core. DONE
// TODO Не давать возможность сломать механику извне. Надо чтобы можно было безопасно вызывать методы из Game DONE
// TODO Все команды пусть будут регистронезависимы. Все должны быть из одного слова. DONE

public static class Program
{
    private static readonly Dictionary<Command, Action<Game, string[]>> Commands;

    static Program()
    {
        Commands = new Dictionary<Command, Action<Game, string[]>>
        {
            { Command.Dress, ExecuteCommandDress }, // TODO назвать dress/robe DONE
            { Command.Drop, ExecuteCommandDrop },
            { Command.Sell, ExecuteCommandSell },
            { Command.Curse, ExecuteCommandCurse },
            { Command.Finish, ExecuteCommandFinish }, // TODO назвать finish DONE
            { Command.Cast, ExecuteCommandCast },
            { Command.Door, ExecuteCommandDoor },
            { Command.Monster, ExecuteCommandMonster },
            { Command.Fight, ExecuteCommandFight },
            { Command.Run, ExecuteCommandRun } // TODO назвать run DONE
        };
    }

    public static void Main(string[] args)
    {
        int playersCount;
        Console.WriteLine("Введите количество игроков для начала игры");
        while (!int.TryParse(Console.ReadLine(), out playersCount))
        {
            Console.WriteLine("Некорректно задано количество игроков");
            Console.WriteLine("Введите количество игроков для начала игры");
        }

        var gameConfig = new GameConfig { PlayersCount = playersCount };
        var game = new Game(gameConfig);
        ExecuteCommand(game);
    }

    private static void ExecuteCommand(Game game)
    {
        game.GetCurrentPlayer().Print();
        while (!game.IsGameOver())
        {
            var allowedCommands = game.PrintAllowedCommands();
            var command = Console.ReadLine();
            var args = command?.Split(" ") ?? [];
            if (args.Length == 0 || !Enum.TryParse(args[0], ignoreCase: true, out Command commandName) ||
                !allowedCommands.Contains(commandName))
            {
                Console.WriteLine("Недоступная команда");
                continue;
            }
            Commands[commandName](game, args);
        }
    }

    private static void ExecuteCommandDress(Game game, string[] args)
    {
        var clothes = ParseArgs<Clothes>(game, args);
        if (clothes.Length == 0)
        {
            return;
        }
        game.Dress(clothes);
        game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandDrop(Game game, string[] args)
    {
        var cards = ParseArgs<Card>(game, args);
        if (cards.Length == 0)
        {
            return;
        }
        game.Drop(cards);
        game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandSell(Game game, string[] args)
    {
        var treasures = ParseArgs<Treasure>(game, args);
        if (treasures.Length == 0)
        {
            return;
        }
        var result = game.Sell(treasures);
        if (!result.Result)
        {
            Console.WriteLine("Недостаточно карт для продажи. Сумма карт должна быть не менее 1000");
        }
        else
        {
            game.GetCurrentPlayer().Print();
        }
    }

    private static void ExecuteCommandCurse(Game game, string[] args)
    {
        var currentPlayer = game.GetCurrentPlayer();
        var isNotCorrectPlayerArg = args.Length != 3 || game.Players.All(player => player.Color.ToString() != args[1]);
        var isNotCorrectCurseArg = !int.TryParse(args[2], out var index) || index > currentPlayer.Cards.Count ||
                                   currentPlayer.Cards[ - 1] is not ICurse;
        if (isNotCorrectPlayerArg || isNotCorrectCurseArg)
        {
            Console.WriteLine("Неправильно заданы параметры команды");
            return;
        }
        var to = game.Players.First(player => player.Color.ToString() == args[1]);
        var curse = (ICurse)game.GetCurrentPlayer().Cards[int.Parse(args[2]) - 1];
        game.Curse(to, curse);
        Console.WriteLine($"Игрок {to.Color}, на тебя наложено проклятие");
    }

    private static void ExecuteCommandFinish(Game game, string[] args)
    {
        var result = game.Finish();
        if (!result.Result)
        {
            Console.WriteLine("У вас на руках больше 5 карт.");
        }
        else
        {
            game.GetCurrentPlayer().Print();
        }
    }

    private static void ExecuteCommandCast(Game game, string[] args)
    {
        var spells = ParseArgs<Spell>(game, args);
        if (spells.Length == 0)
        {
            return;
        }
        var result = game.Cast(spells[0]);
        if (!result.Result)
        {
            Console.WriteLine("Не удалось наложить заклинание.");
        }
        else
        {
            game.GetCurrentPlayer().Print();
        }
    }

    private static void ExecuteCommandDoor(Game game, string[] args)
    {
        var result = game.Door();
        result.Result!.Print();
        game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandMonster(Game game, string[] args)
    {
        var monsters = ParseArgs<Monster>(game, args);
        if (monsters.Length == 0)
        {
            return;
        }
        monsters[0].Print();
        game.Monster(monsters[0]);
        game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandFight(Game game, string[] args)
    {
        var result = game.Fight();
        if (!result.Result)
        {
            Console.WriteLine("Не хватает боевой силы для победы.");
        }
        else
        {
            Console.WriteLine("Победа!");
            game.GetCurrentPlayer().Print();
            //CheckCardsCount(game); // TODO этого не должно быть тут! DONE
        }
    }

    private static void ExecuteCommandRun(Game game, string[] args)
    {
        var result = game.Run();
        Console.WriteLine(result.Result ? "Удалось смыться от монстра!" : "Не удалось смыться. Получи наказание");
        game.GetCurrentPlayer().Print();
    }

    private static T[] ParseArgs<T>(Game game, string[] args) where T : Card
    {
        var currentPlayer = game.GetCurrentPlayer();
        var isNotCorrectCardIndexes = args.Length == 1 || !args.Skip(1).All(arg => int.TryParse(arg, out var index) &&
            index <= currentPlayer.Cards.Count &&
            currentPlayer.Cards[index - 1] is T);
        if (isNotCorrectCardIndexes)
        {
            Console.WriteLine("Неправильно заданы параметры команды");
            return [];
        }

        return args
            .Skip(1)
            .Select(str => (T)game.GetCurrentPlayer().Cards[int.Parse(str) - 1])
            .ToArray();
    }
}