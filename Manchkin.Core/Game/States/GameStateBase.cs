using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;

namespace Manchkin.Core.Game.States;

// Базовый класс состояния: доступных методов нет
internal abstract class GameStateBase(GameProcessor gameProcessor)
{
    /// <summary>
    /// Генератор дверей и сокровищ
    /// </summary>
    protected readonly ICardsGenerator CardsGenerator = gameProcessor.CardsGenerator;
    
    /// <summary>
    /// Массив карт сброса дверей
    /// </summary>
    private readonly Stack<IDoor> _doorsReset  = [];

    /// <summary>
    /// Массив карт сброса сокровищ
    /// </summary>
    private readonly Stack<ITreasure> _treasuresReset = [];
    
    protected readonly GameProcessor GameProcessor = gameProcessor;
    
    protected abstract List<Command> AllowedCommands { get; }
    

    public virtual CommandResult Dress(IClothes[] clothes)
    {
        return new CommandResult(false);
    }

    public virtual CommandResult Drop(ICard[] cards)
    {
        return new CommandResult(false);
    }

    public virtual CommandResultWith<bool> Sell(ITreasure[] treasures)
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual CommandResultWith<bool> Finish()
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual CommandResultWith<bool> Curse(Players.Player to, ICurse curse)
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

    public virtual CommandResultWith<bool> Monster(IMonster monster)
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual CommandResultWith<IDoor> PullDoor()
    {
        return new CommandResultWith<IDoor>(false, null);
    }

    public virtual CommandResultWith<bool> Run()
    {
        return new CommandResultWith<bool>(false, false);
    }

    public virtual CommandResultWith<bool> Fight()
    {
        return new CommandResultWith<bool>(false, false);
    }
    
    public List<Command> GetAllowCommands()
    {
        return AllowedCommands;
    }
    
    protected void Reset<T>(Players.Player player, T[] cards) where T : ICard
    {
        foreach (var card in cards)
        {
            player.Cards.Remove(card);
            switch (card)
            {
                case ITreasure treasure:
                    _treasuresReset.Push(treasure);
                    break;
                case IDoor door:
                    _doorsReset.Push(door);
                    break;
                default:
                    throw new ArgumentException("Invalid card type");
            }
        }
    }
    
    /// <summary>
    /// Возвращаю результат продажи - успешно/не успешно
    /// </summary>
    protected bool SellTreasures(Players.Player player, ITreasure[] treasures)
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
    
    protected void Curse(Players.Player from, Players.Player to, ICurse curse)
    {
        curse.Curse(to);
        Reset(from, [curse]);
    }
    
    protected void FillInventory(Players.Player player, IClothes[] clothes)
    {
        foreach (var c in clothes)
        {
            var returnedClothes = player.Inventory.PutOn(c);
            player.Cards.AddRange(returnedClothes);
        }

        Reset(player, clothes);
    }
    
    protected void ResetCards(Players.Player player, ICard[] cards)
    {
        Reset(player, cards);
    }
    
    protected bool CastOtherSpell(Players.Player player, IOtherSpell otherSpell)
    {
        otherSpell.Cast(player, CardsGenerator);
        Reset(player, [(ICard)otherSpell]);
        return true;
    }
    
    protected bool IsNextMoveAllowed(Players.Player player)
    {
        return player.Cards.Count <= 5;
    }
}