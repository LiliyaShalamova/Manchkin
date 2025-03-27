using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;

namespace Manchkin.Core;

public abstract class GameState
{
    /// <summary>
    /// Генератор дверей
    /// </summary>
    internal readonly CardsGenerator<Door> DoorGenerator = new();
    
    /// <summary>
    /// Генератор сокровищ
    /// </summary>
    internal readonly CardsGenerator<Treasure> TreasureGenerator = new();
    
    /// <summary>
    /// Массив карт сброса дверей
    /// </summary>
    private Stack<Door> DoorsReset { get; } = [];

    /// <summary>
    /// Массив карт сброса сокровищ
    /// </summary>
    private Stack<Treasure> TreasuresReset { get; } = [];
    
    internal void Reset<T>(Player player, T[] cards) where T : Card// TODO переделать чтобы не было варнингов выше при вызове этого метода DONE
    {
        foreach (var card in cards)
        {
            player.Cards.Remove(card);
            switch (card)
            {
                case Treasure treasure:
                    TreasuresReset.Push(treasure);
                    break;
                case Door door:
                    DoorsReset.Push(door);
                    break;
                default:
                    throw new ArgumentException("Invalid card type");
            }
            // TODO помещать в резет DONE
        }
    }
    
    /// <summary>
    /// Возвращаю результат продажи - успешно/не успешно
    /// </summary>
    internal bool SellTreasures(Player player, Treasure[] treasures)
    {
        var sum = treasures.Select(treasure => treasure.Price).Sum();
        if (sum < 1000)
        {
            return false;
        }

        Reset(player, treasures);
        player.IncreaseLevel(sum / 1000);
        return true;
    }
    
    internal void Curse(Player from, Player to, ICurse curse)
    {
        curse.Curse(to);
        Reset(from, [(Curse)curse]);
    }
    
    internal void FillInventory(Player player, Clothes[] clothes)
    {
        foreach (var c in clothes)
        {
            var returnedClothes = player.Inventory.PutOn(c);
            player.Cards.AddRange(returnedClothes);
        }

        Reset(player, clothes);
        // TODO вернуть в руку карту, которая была надета раньше DONE
    }
    
    internal void ResetCards(Player player, Card[] cards) // TODO избавиться от индексов DONE
    {
        Reset(player, cards);
    }
    
    internal bool CastOtherSpell(Player player, IOtherSpell otherSpell)
    {
        // TODO Оставить только использование интерфейса
        otherSpell.Cast(player, TreasureGenerator);
        Reset(player, [(Card)otherSpell]);
        return true;
    }
    
    internal bool IsNextMoveAllowed(Player player)
    {
        return player.Cards.Count <= 5;
    }
}