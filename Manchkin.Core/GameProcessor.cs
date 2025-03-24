using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;

namespace Manchkin.Core;

public class GameProcessor
{
    /// <summary>
    /// Генератор дверей
    /// </summary>
    private readonly CardsGenerator<Door> _doorGenerator = new();
    
    /// <summary>
    /// Генератор сокровищ
    /// </summary>
    private readonly CardsGenerator<Treasure> _treasureGenerator = new();
    
    /// <summary>
    /// Массив карт сброса дверей
    /// </summary>
    private Stack<Door> DoorsReset { get; } = [];

    /// <summary>
    /// Массив карт сброса сокровищ
    /// </summary>
    private Stack<Treasure> TreasuresReset { get; } = [];

    /// <summary>
    /// Текущий бой
    /// </summary>
    public Fight? CurrentFight { get; private set; }

    public void FillInventory(Player player, Clothes[] clothes)
    {
        foreach (var c in clothes)
        {
            var returnedClothes = player.Inventory.PutOn(c);
            player.Cards.AddRange(returnedClothes);
        }

        Reset(player, clothes);
            // TODO вернуть в руку карту, которая была надета раньше DONE
    }
    
    public void ResetCards(Player player, Card[] cards) // TODO избавиться от индексов DONE
    {
        Reset(player, cards);
    }
    
    /// <summary>
    /// Возвращаю результат продажи - успешно/не успешно
    /// </summary>
    public bool Sell(Player player, Treasure[] treasures)
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
    
    public void Curse(Player from, Player to, ICurse curse)
    {
        curse.Curse(to);
        Reset(from, [(Curse)curse]);
    }
    
    /// <summary>
    /// Удалось наложить заклинание или нет
    /// </summary>
    public bool CastSpell(Player player, Spell spell)
    {
        switch (CurrentFight)
        {
            case null when spell is FightingSpell:
            case not null when spell is OtherSpell:
                return false;
            case null when spell is OtherSpell:
            {
                var otherSpell = (IOtherSpell)spell; // TODO Оставить только использование интерфейса
                otherSpell.Cast(player, _treasureGenerator);
                Reset(player, [spell]);
                return true;
            }
            case not null when spell is FightingSpell:
                var fightingSpell = (IFightingSpell)spell;
                fightingSpell.Cast(CurrentFight);
                Reset(player, [spell]);
                return true;
        }

        return false;
    }

    private void Reset(Player player, Card[] cards) // TODO переделать чтобы не было варнингов выше при вызове этого метода
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
            // TODO помещать обратно в резет DONE
        }
    }
    
    public Door PullDoor()
    {
        var door = _doorGenerator.GetCard();
        return door;
    }

    public bool Fight(Player player, Monster monster)
    {
        // TODO добавить обработку уровня с которого монстр начинает сражаться с игроком
        CurrentFight = new Fight(player, monster);
        var playerWin = player.FightingStrength + CurrentFight.FightingStrengthBonus > monster.Level;
        if (playerWin)
        {
            CurrentFight = null;
            GetReward(player, monster);
        }
        
        Reset(player, [monster]);
        return playerWin;
    }

    private void GetReward(Player player, Monster monster)
    {
        for (var i = 0; i < monster.TreasuresCount; i++)
        {
            player.Cards.Add(_treasureGenerator.GetCard());
        }
        player.IncreaseLevel(monster.LevelsCount);
    }
    
    public bool IsNextMoveAllowed(Player player)
    {
        return player.Cards.Count <= 5;
    }

    public bool GetAway()
    {
        var value = Cube.Throw();
        if (value >= CurrentFight.WashBonus)
        {
            CurrentFight = null;
        }
        return value >= CurrentFight.WashBonus;
    }

    public void GetPunished()
    {
        foreach (var monster in CurrentFight.Monsters)
        {
            ((IPunish)monster).Punish(CurrentFight.Player);
        }
        CurrentFight = null;
        
    }

    public bool IsCommandAllowed(Player player, Command command, int phase, int move) //доступна ли команда для игрока в определенной фазе на определённом ходе
    {
        return false;
    }

    public List<Command> GetAllowCommands(int phase, int move)
    {
        var fightingCommands = new List<Command>() { Command.Cast, Command.GetAway};
        var commandsBetweenMoves = new List<Command>() { Command.PutOn, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Next };
        var firstMoveCommands = new List<Command>() { Command.PutOn, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door };
        var secondMoveCommands = new List<Command>() { Command.PutOn, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door, Command.Monster };
        if (CurrentFight != null)
        {
            return fightingCommands;
        }

        if (phase == 1)
        {
            return commandsBetweenMoves;
        }

        return move switch
        {
            1 => firstMoveCommands,
            2 => secondMoveCommands,
            _ => []
        };
    }
}