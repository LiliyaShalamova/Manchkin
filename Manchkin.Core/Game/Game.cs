using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cube;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;
using Manchkin.Core.Players;

namespace Manchkin.Core.Game;
/// <summary>
/// Класс игры
/// </summary>
public class Game
{
    private GameProcessor GameProcessor { get; }

    /// <summary>
    /// Количество уровней в игре
    /// </summary>
    private int LevelsCount { get; }

    /// <summary>
    /// Массив игроков
    /// </summary>
    private Player[] Players { get; }
    
    public Game(
        GameConfig gameConfig,
        ICardRegistrar? cardRegistrator = null,
        IPlayersGenerator? playersGenerator = null,
        ICube? cube = null,
        IRandom? randomNumber = null,
        ICardsGenerator? cardsGenerator = null)
    {
        LevelsCount = gameConfig.LevelsCount;
        cardRegistrator ??= new CardRegistrar(gameConfig.CardsStorage);
        cube ??= new RandomCube();
        randomNumber ??= new RandomNumber();
        cardsGenerator ??= new CardsGenerator(gameConfig.CardsStorage, randomNumber);
        var randomEnumValueGenerator = new RandomEnumValueGenerator(randomNumber);
        playersGenerator ??= new PlayersGenerator(gameConfig, cardsGenerator, randomEnumValueGenerator);
        
        if (gameConfig.UseDefaultCards)
        {
            cardRegistrator.Register();
        }
        
        Players = playersGenerator.Generate().Select(player => player).ToArray();
        
        GameProcessor = new GameProcessor(cube, Players, cardsGenerator);
    }

    public bool IsGameOver()
    {
        return Players.Max(player => player.Level) == LevelsCount;
    }

    public PublicPlayer GetCurrentPlayer()
    {
        return GameProcessor.CurrentPlayer;
    }

    public PublicPlayer? GetPlayerByColor(string color)
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

    public CommandResultWith<bool> Curse(PublicPlayer to, ICurse curse)
    {
        return GameProcessor.CurrentState.Curse((Player)to, curse);
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