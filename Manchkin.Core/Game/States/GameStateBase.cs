using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;
using Manchkin.Core.Players;

namespace Manchkin.Core.Game.States;

// Базовый класс состояния: доступных методов нет
internal abstract class GameStateBase(IGameProcessor gameProcessor)
{
    /// <summary>
    /// Генератор дверей и сокровищ
    /// </summary>
    protected readonly ICardsGenerator CardsGenerator = gameProcessor.CardsGenerator;
    
    /// <summary>
    /// Массив карт сброса дверей
    /// </summary>
    protected Stack<IDoor> DoorsReset { get; } = [];

    /// <summary>
    /// Массив карт сброса сокровищ
    /// </summary>
    protected Stack<ITreasure> TreasuresReset { get; } = [];
    
    protected readonly IGameProcessor GameProcessor = gameProcessor;
    
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

    public virtual CommandResultWith<bool> Curse(Player to, ICurse curse)
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
    
    protected void Reset<T>(Player player, T[] cards) where T : ICard
    {
        foreach (var card in cards)
        {
            player.Cards = player.Cards.Remove(card);
            switch (card)
            {
                case ITreasure treasure:
                    TreasuresReset.Push(treasure);
                    break;
                case IDoor door:
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
    protected bool SellTreasures(Player player, ITreasure[] treasures)
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
    
    protected void Curse(Player from, Player to, ICurse curse)
    {
        curse.Curse(to);
        Reset(from, [curse]);
    }
    
    protected void FillInventory(Player player, IClothes[] clothes)
    {
        foreach (var c in clothes)
        {
            var returnedClothes = player.Inventory.PutOn(c);
            player.Cards = player.Cards.Remove(c);
            player.Cards = player.Cards.AddRange(returnedClothes);
        }
        
        //Reset(player, clothes);
    }
    
    protected void ResetCards(Player player, ICard[] cards)
    {
        Reset(player, cards);
    }
    
    protected bool CastOtherSpell(Player player, IOtherSpell otherSpell)
    {
        var result = otherSpell.Cast(player, CardsGenerator);
        Reset(player, [(ICard)otherSpell]);
        return result.Result;
    }
    
    protected bool IsNextMoveAllowed(Player player)
    {
        return player.Cards.Count <= 5;
    }
}