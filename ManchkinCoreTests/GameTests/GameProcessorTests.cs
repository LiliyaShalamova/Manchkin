using FluentAssertions;
using Manchkin.Core.Cube;
using Manchkin.Core.Game;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;
using Moq;
using Xunit;

namespace ManchkinCoreTests.GameTests;

public class GameProcessorTests
{
    [Fact]
    public void GameProcessorInitializesCorrectly()
    {
        var iCubeMock = new Mock<ICube>(MockBehavior.Strict);
        var iCardsGeneratorMock = new Mock<ICardsGenerator>(MockBehavior.Strict);
        var player = new TestHelper().GenerateEmptyPlayer();
        
        var gameProcessor = new GameProcessor(iCubeMock.Object, [player], iCardsGeneratorMock.Object);
        
        gameProcessor.CurrentState.Should().BeOfType<StartState>();
        gameProcessor.Players.Should().BeEquivalentTo([player]);
        gameProcessor.CurrentPlayer.Should().Be(player);
    }
    
    [Fact]
    public void GameProcessorCreated_ChangeState_CurrentStateChanged()
    {
        var iCubeMock = new Mock<ICube>(MockBehavior.Strict);
        var iCardsGeneratorMock = new Mock<ICardsGenerator>(MockBehavior.Strict);
        var player = new TestHelper().GenerateEmptyPlayer();
        var gameProcessor = new GameProcessor(iCubeMock.Object, [player], iCardsGeneratorMock.Object);
        var newState = new FightState(gameProcessor);
        
        gameProcessor.ChangeState(newState);
        
        gameProcessor.CurrentState.Should().Be(newState);
    }

    [Fact]
    public void GameProcessorCreated_SwitchToNextPlayer_PlayerChangedToNextPlayer()
    {
        var iCubeMock = new Mock<ICube>(MockBehavior.Strict);
        var iCardsGeneratorMock = new Mock<ICardsGenerator>(MockBehavior.Strict);
        var firstPlayer = new TestHelper().GenerateEmptyPlayer();
        var lastPlayer = new TestHelper().GenerateEmptyPlayer();
        var gameProcessor = new GameProcessor(iCubeMock.Object, [firstPlayer, lastPlayer], iCardsGeneratorMock.Object);
        
        gameProcessor.SwitchToNextPlayer();
        
        gameProcessor.CurrentPlayer.Should().Be(lastPlayer);
    }
    
    [Fact]
    public void GameProcessorCreated_SwitchToNextPlayer_PlayerChangedToFirstPlayer()
    {
        var iCubeMock = new Mock<ICube>(MockBehavior.Strict);
        var iCardsGeneratorMock = new Mock<ICardsGenerator>(MockBehavior.Strict);
        var firstPlayer = new TestHelper().GenerateEmptyPlayer();
        var lastPlayer = new TestHelper().GenerateEmptyPlayer();
        var gameProcessor = new GameProcessor(iCubeMock.Object, [firstPlayer, lastPlayer], iCardsGeneratorMock.Object);
        gameProcessor.SwitchToNextPlayer();
        
        gameProcessor.SwitchToNextPlayer();
        
        gameProcessor.CurrentPlayer.Should().Be(firstPlayer);
    }
}