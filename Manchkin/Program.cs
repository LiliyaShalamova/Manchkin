// See https://aka.ms/new-console-template for more information

using Manchkin.Core;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Extensions;

namespace Manchkin;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество игроков для начала игры");
        var playersCount = int.Parse(Console.ReadLine());
        var gameConfig = new GameConfig() {PlayersCount = playersCount};
        var game = new Game(gameConfig);
        PhaseOne(game);
        PhaseTwo(game);
    }

    private static void PhaseOne(Game game)
    {
        Console.WriteLine("Фаза 1. Сброс карт");
        foreach (var player in game.Players)
        {
            //Вывод всех карт игрока
            PrintPlayerInfo(player);
            ExecuteCommand(game, player);
        }
    }

    private static void PhaseTwo(Game game)
    {
        Console.WriteLine("Фаза 2. Игра");
        while (game.Players.Max(player => player.Level) != 10)
        {
            foreach (var player in game.Players)
            {
                Console.WriteLine($"Игрок {player.Color}, ваш ход");
                Console.WriteLine(
                    $"Доступные команды: надеть/продать/сбросить/проклятие/заклинание <№ карты>, вытянуть дверь");
                ExecuteCommand(game, player);
            }
        }
    }

    private static void ExecuteCommand(Game game, Player player)
    {
        string command;
        while ((command = Console.ReadLine()) != "далее" || player.Cards.Count > 5) // TODO вынести в Core
        {
            var commandArray = command.Split(" ");
            switch (commandArray[0])
            {
                case "надеть":
                    var clothes = commandArray.Skip(1).Select(int.Parse).Select(number => (Clothes)player.Cards[number - 1])
                        .ToArray();
                    game.GameProcessor.FillInventory(player, clothes);
                    PrintPlayerInfo(player);
                    break;
                case "сбросить":
                    game.GameProcessor.ResetCards(player, commandArray.Skip(1).Select(int.Parse).ToArray());
                    PrintPlayerInfo(player);
                    break;
                case "продать":
                    var treasures = commandArray.Skip(1).Select(int.Parse).Select(number => (Treasure)player.Cards[number - 1]).ToArray();
                    if (!game.GameProcessor.Sell(player, treasures))
                    {
                        Console.WriteLine("Недостаточно карт для продажи. Сумма карт должна быть не менее 1000");
                    }
                    PrintPlayerInfo(player);
                    break;
                case "далее":
                    if (player.Cards.Count > 5)
                    {
                        Console.WriteLine(
                            "У вас на руках больше 5 карт. Доступные команды: надеть/продать/сбросить/проклятие/заклинание <№ карты>, далее ");
                    }
                    break;
                case "проклятие":
                    var to = game.Players.FirstOrDefault(p => p.Color.ToString() == commandArray[1]);
                    ICurse? curse = player.Cards[int.Parse(commandArray[2]) - 1] as ICurse;
                    game.GameProcessor.Curse(player, to, curse);
                    PrintPlayerInfo(player);
                    break;
                case "заклинание":
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
                    break;
                case "вытянуть дверь":
                    var door = game.GameProcessor.PullDoor();
                    door.Print();
                    if (door is Monster)
                    {
                        if (!game.GameProcessor.Fight(player, door as Monster))
                        {
                            Console.WriteLine($"Доступные команды: заклинание <№ карты>/смыться");
                        }
                        else
                        {
                            Console.WriteLine("Победа!");
                            PrintPlayerInfo(player);
                            Console.WriteLine($"Доступные команды: заклинание <№ карты>/смыться");
                        }
                    }

                    if (door is Curse)
                    {
                        //game.Curse();
                    }

                    break;
            }
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
        Console.WriteLine($"Для начала игры необходимо иметь на руках не более 5 карт"); // убрать все выводы в програм
        Console.WriteLine($"Доступные команды: надеть/продать/сбросить/проклятие/заклинание <№ карты>, далее");
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
}