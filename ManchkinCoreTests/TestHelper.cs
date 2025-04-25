using System.Collections.Immutable;
using AutoFixture;
using Manchkin.Core.Cards;
using Manchkin.Core.Players;

namespace ManchkinCoreTests;

internal class TestHelper
{
    private Fixture _fixture = new();
    
    private readonly Random _random = new();
    
    public Player GenerateEmptyPlayer()
    {
        return new Player((Sex)_random.Next(0, 2), (Color)_random.Next(0, 6), []);
    }

    public Player GeneratePlayerWith(ImmutableList<ICard> cards, Inventory? inventory = null)
    {
        return new Player((Sex)_random.Next(0, 2), (Color)_random.Next(0, 6), cards, inventory);   
    }
}