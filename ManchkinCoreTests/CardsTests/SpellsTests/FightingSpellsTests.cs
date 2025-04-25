using FluentAssertions;
using Manchkin.Core;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Xunit;

namespace ManchkinCoreTests.CardsTests.SpellsTests;

public class FightingSpellsTests
{
    private readonly TestHelper _testHelper = new();
    [Fact]
    public void BlankCartridgeFightingSpellCreated_Cast_DamageBonusAddedToFightingStrength()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new BlankCartridgeFightingSpell();

        spell.Cast(fight);

        fight.FightingStrengthBonus.Should().Be(spell.DamageBonus);
    }
    
    [Fact]
    public void BorschtPackageFightingSpellCreated_Cast_DamageBonusAddedToFightingStrength()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new BorschtPackageFightingSpell();

        spell.Cast(fight);

        fight.FightingStrengthBonus.Should().Be(spell.DamageBonus);
    }
    
    [Fact]
    public void DeadWaterFightingSpellCreated_Cast_MonstersDead()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new DeadWaterFightingSpell();

        spell.Cast(fight);

        fight.Monsters.Should().BeEmpty();
    }
    
    [Fact]
    public void FlasherFightingSpellCreated_Cast_MonstersDead()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new FlasherFightingSpell();

        spell.Cast(fight);

        fight.Monsters.Should().BeEmpty();
    }
    
    [Fact]
    public void HematogenFightingSpellCreated_Cast_DamageBonusAddedToFightingStrength()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new HematogenFightingSpell();

        spell.Cast(fight);

        fight.FightingStrengthBonus.Should().Be(spell.DamageBonus);
    }
    
    [Fact]
    public void HerringUnderFurCoatFightingSpellCreated_Cast_DamageBonusAddedToFightingStrength()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new HerringUnderFurCoatFightingSpell();

        spell.Cast(fight);

        fight.FightingStrengthBonus.Should().Be(spell.DamageBonus);
    }
    
    [Fact]
    public void MiningFarmFightingSpellCreated_Cast_WashBonusAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new MiningFarmFightingSpell();
        var washBonusBefore = fight.WashBonus;

        spell.Cast(fight);
        
        fight.WashBonus.Should().Be(washBonusBefore - spell.WashBonus);
    }
    
    [Fact]
    public void MolotovCocktailFightingSpellCreated_Cast_DamageBonusAddedToFightingStrength()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new MolotovCocktailFightingSpell();

        spell.Cast(fight);

        fight.FightingStrengthBonus.Should().Be(spell.DamageBonus);
    }
    
    [Fact]
    public void ProtectiveTattooFightingSpellCreated_Cast_MonstersDead()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new ProtectiveTattooFightingSpell();

        spell.Cast(fight);

        fight.Monsters.Should().BeEmpty();
    }
    
    [Fact]
    public void ThePowerOfKsivaFightingSpellCreated_Cast_WashBonusAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new ThePowerOfKsivaFightingSpell();
        var washBonusBefore = fight.WashBonus;

        spell.Cast(fight);
        
        fight.WashBonus.Should().Be(washBonusBefore - spell.WashBonus);
    }
    
    [Fact]
    public void ZelenkaFightingSpellCreated_Cast_DamageBonusAddedToFightingStrength()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var spell = new ZelenkaFightingSpell();

        spell.Cast(fight);

        fight.FightingStrengthBonus.Should().Be(spell.DamageBonus);
    }
}