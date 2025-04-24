using FluentAssertions;
using Manchkin.Core.Cube;
using Manchkin.Core.Game;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;
using Moq;
using Xunit;

namespace ManchkinCoreTests.GameProcessorTests;

public class GameProcessorTests
{
    [Fact]
    public void GameProcessorInitializesCorrectly()
    {
        var iCubeMock = new Mock<ICube>();
        var iCardsGeneratorMock = new Mock<ICardsGenerator>();
        var player = new TestHelper().GeneratePlayer();
        
        var gameProcessor = new GameProcessor(iCubeMock.Object, [player], iCardsGeneratorMock.Object);
        
        gameProcessor.CurrentState.Should().BeOfType<StartState>();
        gameProcessor.Players.Should().BeEquivalentTo([player]);
        gameProcessor.CurrentPlayer.Should().Be(player);
    }
    
    [Fact]
    public void GameProcessorCreated_ChangeState_CurrentStateChanged()
    {
        var iCubeMock = new Mock<ICube>();
        var iCardsGeneratorMock = new Mock<ICardsGenerator>();
        var player = new TestHelper().GeneratePlayer();
        var gameProcessor = new GameProcessor(iCubeMock.Object, [player], iCardsGeneratorMock.Object);
        var newState = new FightState(gameProcessor);
        
        gameProcessor.ChangeState(newState);
        
        gameProcessor.CurrentState.Should().Be(newState);
    }

    [Fact]
    public void GameProcessorCreated_SwitchToNextPlayer_PlayerChangedToNextPlayer()
    {
        var iCubeMock = new Mock<ICube>();
        var iCardsGeneratorMock = new Mock<ICardsGenerator>();
        var firstPlayer = new TestHelper().GeneratePlayer();
        var lastPlayer = new TestHelper().GeneratePlayer();
        var gameProcessor = new GameProcessor(iCubeMock.Object, [firstPlayer, lastPlayer], iCardsGeneratorMock.Object);
        
        gameProcessor.SwitchToNextPlayer();
        
        gameProcessor.CurrentPlayer.Should().Be(lastPlayer);
    }
    
    [Fact]
    public void GameProcessorCreated_SwitchToNextPlayer_PlayerChangedToFirstPlayer()
    {
        var iCubeMock = new Mock<ICube>();
        var iCardsGeneratorMock = new Mock<ICardsGenerator>();
        var firstPlayer = new TestHelper().GeneratePlayer();
        var lastPlayer = new TestHelper().GeneratePlayer();
        var gameProcessor = new GameProcessor(iCubeMock.Object, [firstPlayer, lastPlayer], iCardsGeneratorMock.Object);
        gameProcessor.SwitchToNextPlayer();
        
        gameProcessor.SwitchToNextPlayer();
        
        gameProcessor.CurrentPlayer.Should().Be(firstPlayer);
    }
}