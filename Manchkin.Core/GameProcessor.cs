using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;

namespace Manchkin.Core;

public class GameProcessor
{
    /// <summary>
    /// Генератор дверей
    /// </summary>
    private CardsGenerator<Door> _doorGenerator = new();
    
    /// <summary>
    /// Генератор сокровищ
    /// </summary>
    private CardsGenerator<Treasure> _treasureGenerator = new();
    
    /// <summary>
    /// Массив карт сброса дверей
    /// </summary>
    private Stack<Door> DoorsReset { get; set; }

    /// <summary>
    /// Массив карт сброса сокровищ
    /// </summary>
    private Stack<Treasure> TreasuresReset { get; set; }
    
    /// <summary>
    /// Текущий бой
    /// </summary>
    private Fight? CurrentFight { get; set; }

    public GameProcessor()
    {
        DoorsReset = [];
        TreasuresReset = [];
    }
    public void FillInventory(Player player, Clothes[] clothes)
    {
        foreach (var c in clothes)
        {
            player.Inventory.PutOn(c);
        }

        Reset(player, clothes);
    }
    
    public void ResetCards(Player player, int[] numbers)
    {
        Reset(player, numbers);
    }
    
    /// <summary>
    /// Возвращаю результат продажи - успешно/не успешно
    /// </summary>
    /// <returns></returns>
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
    /// <param name="player"></param>
    /// <param name="spellCardNumber"></param>
    /// <returns></returns>
    public bool CastSpell(Player player, Spell spell)
    {
        switch (CurrentFight)
        {
            case null when spell is FightingSpell:
            case not null when spell is OtherSpell:
                return false;
            case null when spell is OtherSpell:
            {
                var otherSpell = (IOtherSpell)spell;
                otherSpell.Cast(player, _treasureGenerator);
                Reset(player, [spell]);
                return true;
            }
            case not null when spell is FightingSpell:
                var fightingSpell = (IFightingSpell)spell;
                fightingSpell.Cast(CurrentFight);
                Reset(player, [spell]);
                return true;
            default:
                break;
        }

        return false;
    }
    
    private void Reset(Player player, int[] numbers)
    {
        foreach (var index in numbers.OrderByDescending(n => n))
        {
            var card = player.Cards[index - 1];
            player.Cards.RemoveAt(index - 1);
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

    private void Reset(Player player, Card[] clothes)
    {
        foreach (var c in clothes)
        {
            player.Cards.Remove(c);
        }
    }
    
    public Door PullDoor()
    {
        var door = _doorGenerator.GetCard();
        return door;
    }

    public bool Fight(Player player, Monster monster)
    {
        CurrentFight = new Fight(player, monster);
        var playerWin = player.FightingStrength > monster.Level;
        if (playerWin)
        {
            CurrentFight = null;
            GetReward(player, monster);
        }
        return playerWin;
    }

    public void GetReward(Player player, Monster monster)
    {
        for (var i = 0; i < monster.TreasuresCount; i++)
        {
            player.Cards.Add(_treasureGenerator.GetCard() as Treasure);
        }
        player.IncreaseLevel(monster.LevelsCount);
    }
}