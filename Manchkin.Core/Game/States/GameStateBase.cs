using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Curses;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Generators;

namespace Manchkin.Core.Game.States;

// Базовый класс состояния: доступных методов нет
internal abstract class GameStateBase(GameProcessor gameProcessor) : IState
{
    /// <summary>
    /// Генератор дверей
    /// </summary>
    protected readonly CardsGenerator<Door> DoorGenerator = new();
    
    /// <summary>
    /// Генератор сокровищ
    /// </summary>
    protected readonly CardsGenerator<Treasure> TreasureGenerator = new();
    
    /// <summary>
    /// Массив карт сброса дверей
    /// </summary>
    protected Stack<Door> DoorsReset { get; } = [];

    /// <summary>
    /// Массив карт сброса сокровищ
    /// </summary>
    protected Stack<Treasure> TreasuresReset { get; } = [];
    
    protected readonly GameProcessor GameProcessor = gameProcessor;

    public virtual CommandResult Dress(Clothes[] clothes)
    {
        return new CommandResult(false);
    }

    public virtual CommandResult Drop(Card[] cards)
    {
        return new CommandResult(false);
    }

    public virtual CommandResultWith<bool> Sell(Treasure[] treasures)
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual CommandResultWith<bool> Finish()
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual CommandResultWith<bool> Curse(Player.Player to, ICurse curse)
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual CommandResultWith<bool> Cast(IFightingSpell spell)
    {
        return new CommandResultWith<bool>(false, false);
    }
    
    public virtual CommandResultWith<bool> Cast(IOtherSpell spell)
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual CommandResultWith<bool> Monster(Monster monster)
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual CommandResultWith<Door> PullDoor()
    {
        return new CommandResultWith<Door>(false, null);
    }

    public virtual CommandResultWith<bool> Run()
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual List<Command> GetAllowCommands()
    {
        return [];
    }

    public virtual CommandResultWith<bool> Fight()
    {
        return new CommandResultWith<bool>(false, false);
    }
    
    protected void Reset<T>(Player.Player player, T[] cards) where T : Card
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
        }
    }
    
    /// <summary>
    /// Возвращаю результат продажи - успешно/не успешно
    /// </summary>
    protected bool SellTreasures(Player.Player player, Treasure[] treasures)
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
    
    protected void Curse(Player.Player from, Player.Player to, ICurse curse)
    {
        curse.Curse(to);
        Reset(from, [(Curse)curse]);
    }
    
    protected void FillInventory(Player.Player player, Clothes[] clothes)
    {
        foreach (var c in clothes)
        {
            var returnedClothes = player.Inventory.PutOn(c);
            player.Cards.AddRange(returnedClothes);
        }

        Reset(player, clothes);
    }
    
    protected void ResetCards(Player.Player player, Card[] cards)
    {
        Reset(player, cards);
    }
    
    protected bool CastOtherSpell(Player.Player player, IOtherSpell otherSpell)
    {
        otherSpell.Cast(player, TreasureGenerator);
        Reset(player, [(Card)otherSpell]);
        return true;
    }
    
    protected bool IsNextMoveAllowed(Player.Player player)
    {
        return player.Cards.Count <= 5;
    }
}