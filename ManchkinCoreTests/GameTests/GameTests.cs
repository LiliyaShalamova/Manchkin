using FluentAssertions;
using Manchkin.Core.Game;
using Manchkin.Core.Generators;
using Moq;
using Xunit;

namespace ManchkinCoreTests.GameTests;

public class GameTests
{
    private readonly TestHelper _testHelper; 

    public GameTests()
    {
        _testHelper = new TestHelper();
    }

    [Fact]
    public void GameIsOver()
    {
        var playersGeneratorMock = new Mock<IPlayersGenerator>(MockBehavior.Strict);
        var player = _testHelper.GenerateEmptyPlayer();
        player.Level = 10;
        playersGeneratorMock.Setup(x => x.Generate()).Returns([player]);
        var gameConfig = new GameConfig();
        var game = new Game(gameConfig, playersGenerator: playersGeneratorMock.Object);
        
        game.IsGameOver().Should().BeTrue();
    }
    
    [Fact]
    public void GameIsNotOver()
    {
        var playersGeneratorMock = new Mock<IPlayersGenerator>(MockBehavior.Strict);
        var player = _testHelper.GenerateEmptyPlayer();
        player.Level = 9;
        playersGeneratorMock.Setup(x => x.Generate()).Returns([player]);
        var gameConfig = new GameConfig();
        var game = new Game(gameConfig, playersGenerator: playersGeneratorMock.Object);
        
        game.IsGameOver().Should().BeFalse();
    }

    [Fact]
    public void GetCurrentPlayer()
    {
        
    }
}