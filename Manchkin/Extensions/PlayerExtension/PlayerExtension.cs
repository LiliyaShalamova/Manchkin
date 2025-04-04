using Manchkin.Core;
using Manchkin.Core.Cards;
using Manchkin.Core.Player;

namespace Manchkin.Extensions.PlayerExtension;

public static class PlayerExtension
{
    public static void Print(this Player player)
    {
        Console.WriteLine($"Игрок {player.Color}: уровень {player.Level}");
        Console.WriteLine();
        player.Inventory.PrintInventory();
        Console.WriteLine();
        Console.WriteLine($"Игрок {player.Color}, ваши карты:");
        player.Cards.PrintCards();
        Console.WriteLine();
    }

    private static void PrintCards(this List<Card> cards)
    {
        for (var i = 1; i <= cards.Count; i++)
        {
            Console.Write($"№ {i} ");
            cards[i - 1].Print();
        }

        Console.WriteLine();
        Console.WriteLine("На руках должно быть не более 5 карт");
    }

    private static void PrintInventory(this Inventory inventory)
    {
        Console.WriteLine("Инвентарь");
        Console.WriteLine($"Общий бонус: {inventory.GetCommonBonus()}");
        inventory.Head?.Print();
        inventory.Torso?.Print();
        inventory.LeftHand?.Print();
        inventory.RightHand?.Print();
        inventory.Legs?.Print();
        inventory.Additional?.ForEach(card => card.Print());
    }
}