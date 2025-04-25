using FluentAssertions;
using Manchkin.Core;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Xunit;

namespace ManchkinCoreTests.FightTests;

public class FightTests
{
    private readonly TestHelper _testHelper = new();
    [Fact]
    public void FightInitialization()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        
        var fight = new Fight(player, monster);
        
        fight.Player.Should().Be(player);
        fight.Monsters.Should().HaveCount(1);
        fight.Monsters[0].Should().Be(monster);
    }

    [Fact]
    public void FightCreated_AddMonster_MonsterAdded()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster1 = new BabaYaga();
        var monster2 = new LittleGreyWolf();
        var fight = new Fight(player, monster1);
        
        fight.AddMonster(monster2);
        
        fight.Monsters.Should().HaveCount(2);
        fight.Monsters[0].Should().Be(monster1);
        fight.Monsters[1].Should().Be(monster2);
    }

    [Fact]
    public void FightCreated_AddFightingStrength_Added()
    {
        var player = _testHelper.GenerateEmptyPlayer();
        var monster = new BabaYaga();
        var fight = new Fight(player, monster);
        var fightingBonus = 5;
        
        fight.AddFightingStrength(fightingBonus);
        
        fight.FightingStrengthBonus.Should().Be(fightingBonus);
    }
}