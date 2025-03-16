// See https://aka.ms/new-console-template for more information

using Manchkin.Core;

namespace Manchkin;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите количество игроков для начала игры");
        var playersCount = int.Parse(Console.ReadLine());
        var game = new Game(playersCount);
        PhaseOne(game);
    }

    private static void PhaseOne(Game game)
    {
        Console.WriteLine("Фаза 1. Сброс карт");
        foreach (var player in game.Players)
        {
            //Вывод всех карт игрока
            PrintPlayerInfo(player);
            string command;
            while ((command = Console.ReadLine()) != "далее" || player.Cards.Count > 5)
            {
                var commandArray = command.Split(" ");
                switch (commandArray[0])
                {
                    case "надеть":
                        game.FillInventory(player, commandArray.Skip(1).Select(int.Parse).ToArray());
                        PrintPlayerInfo(player);
                        break;
                    case "сбросить":
                        game.ResetCards(player, commandArray.Skip(1).Select(int.Parse).ToArray());
                        PrintPlayerInfo(player);
                        break;
                    case "продать":
                        if (!game.Sell(player, commandArray.Skip(1).Select(int.Parse).ToArray()))
                        {
                            Console.WriteLine("Недостаточно карт для продажи. Сумма карт должна быть не менее 1000");
                            PrintPlayerInfo(player);
                        }
                        break;
                    case "далее":
                        if (player.Cards.Count > 5)
                        {
                            Console.WriteLine("У вас на руках больше 5 карт. Доступные команды: надеть/продать/сбросить/проклятие/заклинание <№ карты>, далее ");
                        }
                        break;
                    case "проклятие":
                        game.Curse(player, commandArray[-1], int.Parse(commandArray[-2]));//кто кого проклятие
                        PrintPlayerInfo(player);
                        break;
                    case "заклинание":
                        game.CastASpell(player, int.Parse(commandArray[-1]));
                        PrintPlayerInfo(player);
                        break;
                }
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

