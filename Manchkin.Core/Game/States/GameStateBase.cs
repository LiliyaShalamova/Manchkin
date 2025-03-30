using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;

namespace Manchkin.Core.Game.States;

// TODO переименовать в GameStateBase DONE
// TODO здесь все команды должны быть недоступные, а в наследниках переопределять только доступные DONE
internal abstract class GameStateBase : IState
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
    
    internal readonly GameProcessor GameProcessor;

    internal GameStateBase(GameProcessor gameProcessor)
    {
        GameProcessor = gameProcessor;
    }
    
    public virtual CommandResult<Void> Dress(Clothes[] clothes)
    {
        return new CommandResult<Void>(false, new Void());
    }

    public virtual CommandResult<Void> Drop(Card[] cards)
    {
        return new CommandResult<Void>(false, new Void());
    }

    public virtual CommandResult<bool> Sell(Treasure[] treasures)
    {
        return new CommandResult<bool>(false, false);
    }

    public virtual CommandResult<bool> Finish()
    {
        return new CommandResult<bool>(false, false);
    }

    public virtual CommandResult<bool> Curse(Player to, ICurse curse)
    {
        return new CommandResult<bool>(false, false);
    }

    public virtual CommandResult<bool> Cast(Spell spell)
    {
        return new CommandResult<bool>(false, false);
    }

    public virtual CommandResult<bool> Monster(Monster monster)
    {
        return new CommandResult<bool>(false, false);
    }

    public virtual CommandResult<Door> Door()
    {
        return new CommandResult<Door>(false, null);
    }

    public virtual CommandResult<bool> Run()
    {
        return new CommandResult<bool>(false, false);
    }

    public virtual List<Command> GetAllowCommands()
    {
        return [];
    }

    public virtual CommandResult<bool> Fight()
    {
        return new CommandResult<bool>(false, false);
    }
    
    internal void Reset<T>(Player player, T[] cards) where T : Card
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
    }
    
    internal void ResetCards(Player player, Card[] cards)
    {
        Reset(player, cards);
    }
    
    internal bool CastOtherSpell(Player player, IOtherSpell otherSpell)
    {
        otherSpell.Cast(player, TreasureGenerator);
        Reset(player, [(Card)otherSpell]);
        return true;
    }
    
    internal bool IsNextMoveAllowed(Player player)
    {
        return player.Cards.Count <= 5;
    }
}