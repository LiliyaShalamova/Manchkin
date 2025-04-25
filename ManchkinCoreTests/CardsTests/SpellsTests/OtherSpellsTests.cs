using FluentAssertions;
using Manchkin.Core.Generators;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;
using ManchkinCoreTests.CardsTests.ClothesCardsTests.AdditionalClothesTests;
using Moq;
using Xunit;

namespace ManchkinCoreTests.CardsTests.SpellsTests;

public class OtherSpellsTests
{
    private readonly TestHelper _testHelper = new();
    
    [Fact]
    public void CookPorridgeFromAxeGetLevelOtherSpellCreated_Cast_LevelAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var spell = new CookPorridgeFromAxeGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(1 + spell.LevelBonus);
        result.Result.Should().BeTrue();
    }
    
    [Fact]
    public void CookPorridgeFromAxeGetLevelOtherSpellCreated_Cast_LevelNotAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        player.Level = 9;
        var spell = new CookPorridgeFromAxeGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(9);
        result.Result.Should().BeFalse();
    }
    
    [Fact]
    public void FindRussianTraceGetLevelOtherSpellCreated_Cast_LevelAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var spell = new FindRussianTraceGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(1 + spell.LevelBonus);
        result.Result.Should().BeTrue();
    }
    
    [Fact]
    public void FindRussianTraceGetLevelOtherSpellCreated_Cast_LevelNotAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        player.Level = 9;
        var spell = new FindRussianTraceGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(9);
        result.Result.Should().BeFalse();
    }
    
    [Fact]
    public void GoToBathhouseGetLevelOtherSpellCreated_Cast_LevelAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var spell = new GoToBathhouseGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(1 + spell.LevelBonus);
        result.Result.Should().BeTrue();
    }
    
    [Fact]
    public void GoToBathhouseGetLevelOtherSpellCreated_Cast_LevelNotAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        player.Level = 9;
        var spell = new GoToBathhouseGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(9);
        result.Result.Should().BeFalse();
    }
    
    [Fact]
    public void PaintGrassGetLevelOtherSpellCreated_Cast_LevelAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var spell = new PaintGrassGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(1 + spell.LevelBonus);
        result.Result.Should().BeTrue();
    }
    
    [Fact]
    public void PaintGrassGetLevelOtherSpellCreated_Cast_LevelNotAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        player.Level = 9;
        var spell = new PaintGrassGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(9);
        result.Result.Should().BeFalse();
    }
    
    [Fact]
    public void ResolveCubanMissileCrisisGetLevelOtherSpellCreated_Cast_LevelAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var spell = new ResolveCubanMissileCrisisGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(1 + spell.LevelBonus);
        result.Result.Should().BeTrue();
    }
    
    [Fact]
    public void ResolveCubanMissileCrisisGetLevelOtherSpellCreated_Cast_LevelNotAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        player.Level = 9;
        var spell = new ResolveCubanMissileCrisisGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(9);
        result.Result.Should().BeFalse();
    }
    
    [Fact]
    public void TakeMeteoritePhotoGetLevelOtherSpellCreated_Cast_LevelAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var spell = new TakeMeteoritePhotoGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(1 + spell.LevelBonus);
        result.Result.Should().BeTrue();
    }
    
    [Fact]
    public void TakeMeteoritePhotoGetLevelOtherSpellCreated_Cast_LevelNotAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        player.Level = 9;
        var spell = new TakeMeteoritePhotoGetLevelOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Level.Should().Be(9);
        result.Result.Should().BeFalse();
    }
    
    [Fact]
    public void WantedRingOtherSpellCreated_Cast_CursesRemoved()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        player.AddCurse(new CurseArmorLoss());
        var spell = new WantedRingOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Curses.Should().BeEmpty();
        result.Result.Should().BeTrue();
    }
    
    [Fact]
    public void TreasuresBonusOtherSpellCreated_Cast_TreasuresAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var spell = new TreasuresBonusOtherSpell();
        var cardsGeneratorMock = new Mock<ICardsGenerator>();
        var treasure = new TrulyImpressiveTitle();
        cardsGeneratorMock
            .Setup(cg => cg.GetTreasureCard())
            .Returns(treasure);

        var result = spell.Cast(player, cardsGeneratorMock.Object);

        player.Cards.Should().HaveCount(1);
        player.Cards[0].Should().Be(treasure);
        result.Result.Should().BeTrue();
    }
}