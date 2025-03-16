using System.Diagnostics;
using System.Text.Json.Serialization.Metadata;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;
using Microsoft.VisualBasic.FileIO;

namespace Manchkin.Core;

/// <summary>
/// Класс игры
/// </summary>
public class Game
{
    private Random _random = new();
    private CardsGenerator<Door> _doorGenerator = new();
    private CardsGenerator<Treasure> _treasureGenerator = new();

    /// <summary>
    /// Количество уровней в игре
    /// </summary>
    public int LevelsCount => 10;

    /// <summary>
    /// Массив игроков
    /// </summary>
    public Player[] Players { get; init; }

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

    public Game(int playersCount)
    {
        DoorsReset = [];
        TreasuresReset = [];
        Players = new PlayersGenerator().Generate(playersCount);
    }

    public void FillInventory(Player player, int[] numbers)
    {
        foreach (var number in numbers)
        {
            var card = player.Cards[number - 1];
            switch (card)
            {
                case Smut smut:
                    player.Inventory.Head = smut;
                    break;
                case Shoes shoes:
                    player.Inventory.Legs = shoes;
                    break;
                case BulletproofVest vest:
                    player.Inventory.Torso = vest;
                    break;
                case Weapon weapon:
                {
                    if (player.Inventory.LeftHand == null || player.Inventory.LeftHand != null && player.Inventory.RightHand != null)
                    {
                        if (weapon.HandsAmount == 2)
                        {
                            player.Inventory.LeftHand = weapon;
                            player.Inventory.RightHand = weapon;
                        }
                        else
                        {
                            player.Inventory.LeftHand = weapon;
                        }
                    }
                    else if (player.Inventory.RightHand == null)
                    {
                        if (weapon.HandsAmount == 2)
                        {
                            player.Inventory.LeftHand = weapon;
                            player.Inventory.RightHand = weapon;
                        }
                        else
                        {
                            player.Inventory.RightHand = weapon;
                        }
                    }
                    break;
                }
                case Clothes clothes:
                    player.Inventory.Additional?.Add(clothes);
                    break;
            }
        }

        foreach (var index in numbers.OrderByDescending(n => n))
        {
            var card = player.Cards[index - 1];
            TreasuresReset.Push((Treasure)card);
            player.Cards.RemoveAt(index - 1);
        }
    }

    public void ResetCards(Player player, int[] numbers)
    {
        foreach (var index in numbers.OrderByDescending(n => n))
        {
            var card = player.Cards[index - 1];
            player.Cards.RemoveAt(index - 1);
            if (card is Treasure treasure)
            {
                TreasuresReset.Push(treasure);
            }
            else
            {
                DoorsReset.Push((Door)card);
            }
        }
    }

    /// <summary>
    /// Возвращаю результат продажи - успешно/не успешно
    /// </summary>
    /// <returns></returns>
    public bool Sell(Player player, int[] numbers)
    {
        var sum = numbers.Select(number => ((Treasure)player.Cards[number - 1]).Price).Sum();
        if (sum < 1000)
        {
            return false;
        }
        else
        {
            ResetCards(player, numbers);
            player.IncreaseLevel(sum / 1000);
            return true;
        }
    }

    public void Curse(Player player, string whomCurses, int curseCardNumber)
    {
        var curse = player.Cards[curseCardNumber - 1];
        var whomCursesPlayer = Players.Where(p => p.Color.ToString() == whomCurses);
    }

    public void CastASpell(Player player, int spellCardNumber)
    {
        var spell = player.Cards[spellCardNumber - 1];
    }
}