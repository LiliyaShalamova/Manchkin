using System.Collections.Immutable;
using FluentAssertions;
using Manchkin.Core;
using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Cube;
using Manchkin.Core.Game;
using Manchkin.Core.Game.States;
using Manchkin.Core.Generators;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Players;
using ManchkinCoreTests.PlayerTests;
using Moq;
using Xunit;

namespace ManchkinCoreTests.GameTests.GameStateTests;

public class FightStateTests
{
    private readonly FightState _state;
    private readonly TestHelper _testHelper = new();
    private readonly Mock<IGameProcessor> _iGameProcessorMock = new(MockBehavior.Strict);
    private readonly ITreasure _treasure;

    public FightStateTests()
    {
        var cardGeneratorMock = new Mock<ICardsGenerator>();
        _treasure = new TrulyImpressiveTitle();
        cardGeneratorMock.Setup(x => x.GetTreasureCard()).Returns(_treasure);
        _iGameProcessorMock.Setup(x => x.CardsGenerator).Returns(cardGeneratorMock.Object);
        _state = new FightState(_iGameProcessorMock.Object);
    }
    
    [Fact]
    public void FightStateCreated_GetAllowedCommands_CommandsCorrect()
    {
        _state.GetAllowCommands().Should().BeEquivalentTo([Command.Cast, Command.Run, Command.Fight]);
    }

    [Fact]
    public void FightStateCreated_CastFightingSpell_Success()
    {
        var spellMock = new Mock<IFightingSpell>();
        var player = _testHelper.GeneratePlayerWith([spellMock.Object]);
        var fightMock = new Mock<IFight>();
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);
        _iGameProcessorMock.Setup(x => x.CurrentFight).Returns(fightMock.Object);

        var result = _state.Cast(spellMock.Object);

        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, true));
        //проверить сброс
        player.Cards.Should().BeEmpty();
        spellMock.Verify(x => x.Cast(fightMock.Object), Times.Once);
    }

    [Fact]
    public void FightStateCreated_RunCubeFaceFive_Success()
    {
        var monster1 = new BabaYaga();
        var monster2 = new Viy();
        var monsters = new List<IMonster> { monster1, monster2 };
        var player = _testHelper.GeneratePlayerWith(monsters.ToImmutableList<ICard>());
        var cubeMock = new Mock<ICube>();
        cubeMock.Setup(x => x.Throw()).Returns(CubeFace.Five);
        var fightMock = new Mock<IFight>();
        fightMock.Setup(x => x.Monsters).Returns(monsters);
        fightMock.Setup(x => x.WashBonus).Returns(5);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);
        _iGameProcessorMock.Setup(x => x.Cube).Returns(cubeMock.Object);
        _iGameProcessorMock.Setup(x => x.CurrentFight).Returns(fightMock.Object);
        _iGameProcessorMock.SetupSet(x => x.CurrentFight = It.IsAny<IFight?>());
        _iGameProcessorMock.Setup(x => x.ChangeState(It.IsAny<IState>()));

        var result = _state.Run();

        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, true));
        player.Cards.Should().BeEmpty();
        player.Level.Should().Be(1);
        //player.Cards.Should().HaveCount(monster1.TreasuresCount + monster2.TreasuresCount);
        //player.Level.Should().Be(1 + monster1.LevelsCount + monster2.LevelsCount);
        //player.Cards.All(card => card == _treasure).Should().BeTrue();
        _iGameProcessorMock.Verify(x => x.ChangeState(It.IsAny<FirstMoveState>()), Times.Once);
        _iGameProcessorMock.VerifySet(x => x.CurrentFight = null, Times.Once);
        //проверить сбросы
    }
    
    [Fact]
    public void FightStateCreated_RunCubeFaceFour_NotSuccess()
    {
        var monster1 = new BabaYaga();
        var monster2 = new Viy();
        var monsters = new List<IMonster> { monster1, monster2 };
        var player = _testHelper.GeneratePlayerWith(monsters.ToImmutableList<ICard>());
        var cubeMock = new Mock<ICube>();
        cubeMock.Setup(x => x.Throw()).Returns(CubeFace.Four);
        var fightMock = new Mock<IFight>();
        fightMock.Setup(x => x.Monsters).Returns(monsters);
        fightMock.Setup(x => x.WashBonus).Returns(5);
        fightMock.Setup(x => x.Player).Returns(player);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);
        _iGameProcessorMock.Setup(x => x.Cube).Returns(cubeMock.Object);
        _iGameProcessorMock.Setup(x => x.CurrentFight).Returns(fightMock.Object);
        _iGameProcessorMock.SetupSet(x => x.CurrentFight = It.IsAny<IFight?>());
        _iGameProcessorMock.Setup(x => x.ChangeState(It.IsAny<IState>()));

        var result = _state.Run();

        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, false));
        player.Cards.Should().BeEmpty();
        player.Level.Should().Be(1);
        _iGameProcessorMock.Verify(x => x.ChangeState(It.IsAny<FirstMoveState>()), Times.Once);
        _iGameProcessorMock.VerifySet(x => x.CurrentFight = null, Times.Once);
        //проверить сбросы
    }
    
    [Fact]
    public void FightStateCreated_RunCubeFaceSeven_Exception()
    {
        var monster1 = new BabaYaga();
        var monster2 = new Viy();
        var monsters = new List<IMonster> { monster1, monster2 };
        var player = _testHelper.GeneratePlayerWith(monsters.ToImmutableList<ICard>());
        var cubeMock = new Mock<ICube>();
        cubeMock.Setup(x => x.Throw()).Returns((CubeFace)7);
        var fightMock = new Mock<IFight>();
        fightMock.Setup(x => x.Monsters).Returns(monsters);
        fightMock.Setup(x => x.WashBonus).Returns(5);
        fightMock.Setup(x => x.Player).Returns(player);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);
        _iGameProcessorMock.Setup(x => x.Cube).Returns(cubeMock.Object);
        _iGameProcessorMock.Setup(x => x.CurrentFight).Returns(fightMock.Object);
        _iGameProcessorMock.SetupSet(x => x.CurrentFight = It.IsAny<IFight?>());
        _iGameProcessorMock.Setup(x => x.ChangeState(It.IsAny<IState>()));

        Action act = () => _state.Run();
        
        act.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("Значение грани куба должно быть от 1 до 6 (Parameter 'value')");
        
    }

    [Fact]
    public void FightStateCreated_Fight_WinStateChangedToFinishState()
    {
        var monster1 = new LittleGreyWolf();
        var monster2 = new ShoesLossMonster();
        var playerCards = new List<ICard>
        {
            monster1, monster2, new BigVest(), new FeltBoots(), new TrulyImpressiveTitle(), 
            new CurseArmorLoss()
        };
        var player = _testHelper.GeneratePlayerWith(playerCards.ToImmutableList());
        player.Inventory.PutOn(new BigWeapon());
        var fightMock = new Mock<IFight>();
        fightMock.Setup(x => x.Monsters).Returns([monster1, monster2]);
        fightMock.Setup(x => x.FightingStrengthBonus).Returns(0);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);
        _iGameProcessorMock.Setup(x => x.CurrentFight).Returns(fightMock.Object);
        _iGameProcessorMock.SetupSet(x => x.CurrentFight = It.IsAny<IFight?>());
        _iGameProcessorMock.Setup(x => x.ChangeState(It.IsAny<IState>()));
        _iGameProcessorMock.Setup(x => x.SwitchToNextPlayer());

        var result = _state.Fight();

        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, true));
        player.Cards.Should().HaveCount(4 + monster1.TreasuresCount + monster2.TreasuresCount);
        player.Level.Should().Be(1 + monster1.LevelsCount + monster2.LevelsCount);
        _iGameProcessorMock.Verify(x => x.ChangeState(It.IsAny<FinishState>()), Times.Once);
        _iGameProcessorMock.VerifySet(x => x.CurrentFight = null, Times.Once);
        _iGameProcessorMock.Verify(x => x.SwitchToNextPlayer(), Times.Never);
    }
    
    [Fact]
    public void FightStateCreated_Fight_WinStateChangedToFirstMoveState()
    {
        var monster1 = new LittleGreyWolf();
        var monster2 = new ShoesLossMonster();
        var monsters = new List<IMonster> { monster1, monster2 };
        var player = _testHelper.GeneratePlayerWith(monsters.ToImmutableList<ICard>());
        player.Inventory.PutOn(new BigWeapon());
        var fightMock = new Mock<IFight>();
        fightMock.Setup(x => x.Monsters).Returns(monsters);
        fightMock.Setup(x => x.FightingStrengthBonus).Returns(0);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);
        _iGameProcessorMock.Setup(x => x.CurrentFight).Returns(fightMock.Object);
        _iGameProcessorMock.SetupSet(x => x.CurrentFight = It.IsAny<IFight?>());
        _iGameProcessorMock.Setup(x => x.ChangeState(It.IsAny<IState>()));
        _iGameProcessorMock.Setup(x => x.SwitchToNextPlayer());

        var result = _state.Fight();

        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, true));
        player.Cards.Should().HaveCount(monster1.TreasuresCount + monster2.TreasuresCount);
        player.Level.Should().Be(1 + monster1.LevelsCount + monster2.LevelsCount);
        player.Cards.All(card => card == _treasure).Should().BeTrue();
        _iGameProcessorMock.Verify(x => x.ChangeState(It.IsAny<FirstMoveState>()), Times.Once);
        _iGameProcessorMock.VerifySet(x => x.CurrentFight = null, Times.Once);
        _iGameProcessorMock.Verify(x => x.SwitchToNextPlayer(), Times.Once);
    }
    
    [Fact]
    public void FightStateCreated_Fight_LossStateChangedToFirstMoveState()
    {
        var monster1 = new IvanTheTerrible();
        var monster2 = new ShoesLossMonster();
        var monsters = new List<IMonster> { monster1, monster2 };
        var player = _testHelper.GeneratePlayerWith(monsters.ToImmutableList<ICard>());
        player.Inventory.PutOn(new BigWeapon());
        var fightMock = new Mock<IFight>();
        fightMock.Setup(x => x.Monsters).Returns(monsters);
        fightMock.Setup(x => x.FightingStrengthBonus).Returns(0);
        fightMock.Setup(x => x.Player).Returns(player);
        _iGameProcessorMock.Setup(x => x.CurrentPlayer).Returns(player);
        _iGameProcessorMock.Setup(x => x.CurrentFight).Returns(fightMock.Object);
        _iGameProcessorMock.SetupSet(x => x.CurrentFight = It.IsAny<IFight?>());
        _iGameProcessorMock.Setup(x => x.ChangeState(It.IsAny<IState>()));
        _iGameProcessorMock.Setup(x => x.SwitchToNextPlayer());

        var result = _state.Fight();

        result.Should().BeEquivalentTo(new CommandResultWith<bool>(true, false));
        player.Cards.Should().BeEmpty();
        player.Level.Should().Be(1);
        _iGameProcessorMock.Verify(x => x.ChangeState(It.IsAny<FirstMoveState>()), Times.Once);
        _iGameProcessorMock.VerifySet(x => x.CurrentFight = null, Times.Once);
        _iGameProcessorMock.Verify(x => x.SwitchToNextPlayer(), Times.Once);
    }

    [Fact]
    public void FightStateCreated_Dress_CommandNotAllowed()
    {
        var result = _state.Dress([new BigSmut()]);
        
        result.Should().BeEquivalentTo(new CommandResult(false));
    }
    
    [Fact]
    public void FightStateCreated_Drop_CommandNotAllowed()
    {
        var result = _state.Drop([new BigSmut()]);
        
        result.Should().BeEquivalentTo(new CommandResult(false));
    }
    
    [Fact]
    public void FightStateCreated_Sell_CommandNotAllowed()
    {
        var result = _state.Sell([new BigSmut()]);
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(false, false));
    }
    
    [Fact]
    public void FightStateCreated_Finish_CommandNotAllowed()
    {
        var result = _state.Finish();
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(false, false));
    }
    
    [Fact]
    public void FightStateCreated_Curse_CommandNotAllowed()
    {
        var result = _state.Curse(_testHelper.GenerateEmptyPlayer(), new CurseArmorLoss());
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(false, false));
    }
    
    [Fact]
    public void FightStateCreated_CastOtherSpell_CommandNotAllowed()
    {
        var result = _state.Cast(new TakeMeteoritePhotoGetLevelOtherSpell());
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(false, false));
    }
    
    [Fact]
    public void FightStateCreated_Monster_CommandNotAllowed()
    {
        var result = _state.Monster(new BabaYaga());
        
        result.Should().BeEquivalentTo(new CommandResultWith<bool>(false, false));
    }
    
    [Fact]
    public void FightStateCreated_PullDoor_CommandNotAllowed()
    {
        var result = _state.PullDoor();
        
        result.Should().BeEquivalentTo(new CommandResultWith<IDoor>(false, null));
    }
}