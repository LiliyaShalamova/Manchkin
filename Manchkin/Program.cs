using Manchkin.Core;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Game;
using Manchkin.Core.Game.States;
using Manchkin.Extensions;
using Manchkin.Extensions.GameProcessorExtension;
using Manchkin.Extensions.PlayerExtension;

namespace Manchkin;

//TODO добавить в командах, что если игрок мертв, надо снова выдать 8 карт
// TODO сделать возможность передачи своих карточек из Console *
// TODO максимально всё сокрыть (модификаторы доступа)
// TODO убрать дублирование Game, переименовать в args DONE
// TODO удалить фазы DONE
// TODO избавиться от try catch
// TODO Надо инкапсулировать всю механику. Пользователь не должен ничего знать про внутреннюю реализацию Core.
// TODO Не давать возможность сломать механику извне. Надо чтобы можно было безопасно вызывать методы из Game DONE
// TODO Все команды пусть будут регистронезависимы. Все должны быть из одного слова.

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
        while (!int.TryParse(Console.ReadLine() ?? throw new InvalidOperationException(), out playersCount))
        {
            Console.WriteLine("Некорректно задано количество игроков");
            Console.WriteLine("Введите количество игроков для начала игры");
        }

        var gameConfig = new GameConfig { PlayersCount = playersCount };
        var game = new Game(gameConfig, new MyCube());
        ExecuteCommand(game);
    }

    private static void ExecuteCommand(Game game)
    {
        game.GetCurrentPlayer().Print();
        while (!game.IsGameOver())
        {
            Command commandName;
            string[] args;
            var allowedCommands = game.PrintAllowedCommands();
            try
            {
                var command = Console.ReadLine();
                args = command.Split(" ");
                commandName = Enum.Parse<Command>(args[0]);
                if (!allowedCommands.Contains(commandName))
                {
                    Console.WriteLine("Недоступная команда.");
                    continue;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Недоступная команда.");
                continue;
            }

            try
            {
                Commands[commandName](game, args);
            }
            catch (Exception)
            {
                Console.WriteLine("Неправильно заданы параметры команды");
            }
        }
    }
    
    private static void CheckCardsCount(Game game)
    {
        ExecuteCommand(game);
    }

    private static void ExecuteCommandDress(Game game, string[] args)
    {
        var clothes = ParseArgs<Clothes>(game, args);
        game.PutOn(clothes);
        game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandDrop(Game game, string[] args)
    {
        var cards = ParseArgs<Card>(game, args);
        game.Drop(cards);
        game.GetCurrentPlayer().Print();
    }

    private static void ExecuteCommandSell(Game game, string[] args)
    {
        var treasures = ParseArgs<Treasure>(game, args);
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
        var to = game.Players.First(player => player.Color.ToString() == args[1]);
        var curse = game.GetCurrentPlayer().Cards[int.Parse(args[2]) - 1] as ICurse;
        game.Curse(to, curse);
        Console.WriteLine($"Игрок {to.Color}, на тебя наложено проклятие");
    }

    private static void ExecuteCommandFinish(Game game, string[] args)
    {
        var result = game.Next();
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
        var spell = game.GetCurrentPlayer().Cards[int.Parse(args[1]) - 1] as Spell;
        var result = game.Cast(spell);
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
    }

    private static void ExecuteCommandMonster(Game game, string[] args)
    {
        var monster = (Monster)game.GetCurrentPlayer().Cards[int.Parse(args[1]) - 1];
        monster.Print();
        game.Monster(monster);
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
            CheckCardsCount(game); // TODO этого не должно быть тут!
        }
    }

    private static void ExecuteCommandRun(Game game, string[] args)
    {
        var result = game.GetAway();
        Console.WriteLine(result.Result ? "Удалось смыться от монстра!" : "Не удалось смыться. Получи наказание");
    }

    private static T[] ParseArgs<T>(Game game, string[] args) where T: Card
    {
        return args
            .Skip(1)
            .Select(str => (T)game.GetCurrentPlayer().Cards[int.Parse(str) - 1])
            .ToArray();
    }
}