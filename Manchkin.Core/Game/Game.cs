using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Curses;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Cube;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;

namespace Manchkin.Core.Game;
/// <summary>
/// Класс игры
/// </summary>
public class Game
{
    private GameProcessor GameProcessor { get; set; }

    /// <summary>
    /// Количество уровней в игре
    /// </summary>
    private int _levelsCount = 10;

    /// <summary>
    /// Массив игроков
    /// </summary>
    public Player.Player[] Players { get; }

    public Game(GameConfig gameConfig, IPlayersGenerator playersGenerator, ICube cube)
    {
        Players = playersGenerator.Generate(gameConfig.PlayersCount);
        GameProcessor = new GameProcessor(cube, Players);
    }

    public Game(GameConfig gameConfig, ICube cube)
    {
        Players = new PlayersGenerator().Generate(gameConfig.PlayersCount);
        GameProcessor = new GameProcessor(cube, Players);
    }
    
    public Game(GameConfig gameConfig)
    {
        Players = new PlayersGenerator().Generate(gameConfig.PlayersCount);
        GameProcessor = new GameProcessor(new RandomCube(), Players);
    }

    public bool IsGameOver()
    {
        return Players.Max(player => player.Level) == _levelsCount;
    }

    public Player.Player GetCurrentPlayer()
    {
        return GameProcessor.CurrentPlayer;
    }

    public Player.Player? GetPlayerByColor(string color)
    {
        return Players.FirstOrDefault(player => player.Color.ToString() == color);
    }

    public CommandResult Dress(IClothes[] clothes)
    {
        return GameProcessor.CurrentState.Dress(clothes);
    }

    public CommandResult Drop(ICard[] cards)
    {
        return GameProcessor.CurrentState.Drop(cards);
    }

    public CommandResultWith<bool> Sell(ITreasure[] treasures)
    {
        return GameProcessor.CurrentState.Sell(treasures);
    }

    public CommandResultWith<bool> Curse(Player.Player to, ICurse curse)
    {
        return GameProcessor.CurrentState.Curse(to, curse);
    }

    public CommandResultWith<bool> Finish()
    {
        return GameProcessor.CurrentState.Finish();
    }

    public CommandResultWith<bool> Cast(ISpell spell)
    {
        return spell switch
        {
            IFightingSpell fightingSpell => GameProcessor.CurrentState.Cast(fightingSpell),
            IOtherSpell otherSpell => GameProcessor.CurrentState.Cast(otherSpell),
            _ => new CommandResultWith<bool>(true, false)
        };
    }

    public CommandResultWith<bool> Monster(IMonster monster)
    {
        return GameProcessor.CurrentState.Monster(monster);
    }

    public CommandResultWith<IDoor> PullDoor()
    {
        return GameProcessor.CurrentState.PullDoor();
    }

    public CommandResultWith<bool> Run()
    {
        return GameProcessor.CurrentState.Run();
    }

    public List<Command> GetAllowCommands()
    {
        return GameProcessor.CurrentState.GetAllowCommands();
    }

    public CommandResultWith<bool> Fight()
    {
        return GameProcessor.CurrentState.Fight();
    }
}