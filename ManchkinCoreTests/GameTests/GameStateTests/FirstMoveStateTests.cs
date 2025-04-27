using FluentAssertions;
using Manchkin.Core;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Game;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Players;
using Moq;
using Xunit;

namespace ManchkinCoreTests.GameTests.GameStateTests;

public class FirstMoveStateTests
{
    private readonly FirstMoveState _state;
    private readonly TestHelper _testHelper = new();
    private readonly Mock<IGameProcessor> _iGameProcessorMock = new(MockBehavior.Strict);

    public FirstMoveStateTests()
    {
        var cardsGeneratorMock = new Mock<ICardsGenerator>(MockBehavior.Strict);
        var player = _testHelper.GenerateEmptyPlayer();
        player.Level = 2;
        player.IsDead = false;
        _iGameProcessorMock.Setup(x => x.CardsGenerator).Returns(cardsGeneratorMock.Object);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);
        _state = new FirstMoveState(_iGameProcessorMock.Object);
    }
    
    [Fact]
    public void FirstMoveStateCreated_GetAllowedCommands_CommandsCorrect()
    {
        _state.GetAllowCommands().Should().BeEquivalentTo([Command.Dress, Command.Drop, Command.Sell, Command.Cast, Command.Curse, Command.Door]);
    }
    
    [Fact]
    public void FirstMoveStateCreated_Dress_ClothesDressed()
    {
        var clothes1 = new Ukokoshnik();
        var clothes2 = new Ushanka();
        var inventory = new Inventory(clothes1);
        var player = _testHelper.GeneratePlayerWith([clothes2], inventory);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);

        var result = _state.Dress([clothes2]);
        
        result.Should().BeEquivalentTo(new CommandResult(true));
        player.Inventory.Head.Should().Be(clothes2);
        player.Cards.Should().HaveCount(1);
        player.Cards[0].Should().Be(clothes1);
    }

    [Fact]
    public void FirstMoveStateCreated_DropTreasure_Dropped()
    {
        var treasure = new Ukokoshnik();
        var player = _testHelper.GeneratePlayerWith([treasure]);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);

        var result = _state.Drop([treasure]);
        
        result.Should().BeEquivalentTo(new CommandResult(true));
        player.Cards.Should().BeEmpty();
        //проверить, что карта сброшена в сброс сокровищ
    }
    
    [Fact]
    public void FirstMoveStateCreated_DropDoor_Dropped()
    {
        var door = new ShoesLossMonster();
        var player = _testHelper.GeneratePlayerWith([door]);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);

        var result = _state.Drop([door]);
        
        result.Should().BeEquivalentTo(new CommandResult(true));
        player.Cards.Should().BeEmpty();
        //проверить, что карта сброшена в сброс дверей
    }

    [Fact]
    public void FirstMoveStateCreated_SellTreasures_Success()
    {
        var treasure1 = new Ukokoshnik();
        var treasure2 = new Ushanka();
        var player = _testHelper.GeneratePlayerWith([treasure1, treasure2]);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);

        var result = _state.Sell([treasure1, treasure2]);
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, true));
        player.Cards.Should().BeEmpty();
        player.Level.Should().Be(2);
        //проверить, что карта сброшена в сброс сокровищ
    }
    
    [Fact]
    public void FirstMoveStateCreated_SellTreasures_NotSuccess()
    {
        var treasure1 = new Ukokoshnik();
        var player = _testHelper.GeneratePlayerWith([treasure1]);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);

        var result = _state.Sell([treasure1]);
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, false));
        player.Cards.Should().HaveCount(1);
        player.Level.Should().Be(1);
        //проверить, что карта не сброшена в сброс сокровищ
    }
    
    [Fact]
    public void FirstMoveStateCreated_Curse_Success()
    {
        var curse = new CurseArmorLoss();
        var player1 = _testHelper.GeneratePlayerWith([curse]);
        var player2 = _testHelper.GeneratePlayerWith([], new Inventory(torso: new MithrilArmor()));
        _iGameProcessorMock.Setup(x => x.Players).Returns([player1, player2]);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player1);
        
        var result = _state.Curse(player2, curse);
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, true));
        player1.Cards.Should().BeEmpty();
        //проверить сброс дверей
        player2.Inventory.Torso.Should().BeNull(); // или можно как-то по-другому проверить, что curse карточки вызвался
    }

    [Fact]
    public void FirstMoveStateCreated_Cast_Success()
    {
        var spell = new CookPorridgeFromAxeGetLevelOtherSpell();
        var player = _testHelper.GeneratePlayerWith([spell]);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);

        var result = _state.Cast(spell);
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, true));
        player.Level.Should().Be(2);
        player.Cards.Should().BeEmpty();
    }
    
    [Fact]
    public void FirstMoveStateCreated_Cast_NotSuccess()
    {
        var spell = new CookPorridgeFromAxeGetLevelOtherSpell();
        var player = _testHelper.GeneratePlayerWith([spell]);
        player.Level = 9;
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);

        var result = _state.Cast(spell);
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, false));
        player.Level.Should().Be(9);
        player.Cards.Should().BeEmpty();
    }
    
    [Fact]
    public void FirstMoveStateCreated_Fight_CommandNotAllowed()
    {
        var result = _state.Fight();
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(false, false));
    }
    
    [Fact]
    public void FirstMoveStateCreated_Monster_CommandNotAllowed()
    {
        var result = _state.Monster(new BabaYaga());
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(false, false));
    }
    
    [Fact]
    public void FirstMoveStateCreated_Run_CommandNotAllowed()
    {
        var result = _state.Run();
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(false, false));
    }
    
    [Fact]
    public void FirstMoveStateCreated_CastFightingSpell_CommandNotAllowed()
    {
        var result = _state.Cast(new ZelenkaFightingSpell());
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(false, false));
    }
    
    [Fact]
    public void FirstMoveStateCreated_PullDoor_DoorIsMonster()
    {
        var door = new Viy();
        var cardsGeneratorMock = new Mock<ICardsGenerator>(MockBehavior.Strict);
        cardsGeneratorMock.Setup(x => x.GetDoorCard()).Returns(door);
        _iGameProcessorMock.Setup(x => x.CardsGenerator).Returns(cardsGeneratorMock.Object);
        _iGameProcessorMock.Setup(x => x.ChangeState(It.IsAny<FightState>()));
        _iGameProcessorMock.SetupSet(x => x.CurrentFight = It.IsAny<IFight>());
        var state = new FirstMoveState(_iGameProcessorMock.Object);
        
        var result = state.PullDoor();
        
        result.Should().BeEquivalentTo(new CommandResultWith<IDoor>(true, door));
        _iGameProcessorMock.Verify(x => x.ChangeState(It.IsAny<FightState>()), Times.Once());
        _iGameProcessorMock.VerifySet(x => x.CurrentFight = It.IsAny<IFight>(), Times.Once());
    }
    
    [Fact]
    public void FirstMoveStateCreated_PullDoor_DoorIsCurse()
    {
        var door = new PaintedLevelLossCurse();
        var cardsGeneratorMock = new Mock<ICardsGenerator>(MockBehavior.Strict);
        cardsGeneratorMock.Setup(x => x.GetDoorCard()).Returns(door);
        _iGameProcessorMock.Setup(x => x.CardsGenerator).Returns(cardsGeneratorMock.Object);
        _iGameProcessorMock.Setup(x => x.ChangeState(It.IsAny<SecondMoveState>()));
        var state = new FirstMoveState(_iGameProcessorMock.Object);
        
        var result = state.PullDoor();
        
        result.Should().BeEquivalentTo(new CommandResultWith<IDoor>(true, door));
        _iGameProcessorMock.Verify(x => x.ChangeState(It.IsAny<SecondMoveState>()), Times.Once());
        _iGameProcessorMock.Object.CurrentPlayer.Level.Should().Be(1);
        //проверить сброс
    }

    [Fact]
    public void FirstMoveStateCreated_InitializationWithDeadPlayer_DealCardsToPlayer()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        player.IsDead = true;
        var cardsGeneratorMock = new Mock<ICardsGenerator>(MockBehavior.Strict);
        cardsGeneratorMock.Setup(x => x.GetDoorCard()).Returns(new Viy());
        cardsGeneratorMock.Setup(x => x.GetTreasureCard()).Returns(new Ukokoshnik());
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);
        _iGameProcessorMock.Setup(x => x.CardsGenerator).Returns(cardsGeneratorMock.Object);

        var state = new FirstMoveState(_iGameProcessorMock.Object);

        player.Cards.Should().HaveCount(8);
        player.IsDead.Should().BeFalse();
    }
}