using AutoFixture;
using Manchkin.Core.Players;

namespace ManchkinCoreTests;

internal class TestHelper
{
    private Fixture _fixture = new();
    
    private readonly Random _random = new();
    
    public Player GeneratePlayer()
    {
        return new Player((Sex)_random.Next(0, 2), (Color)_random.Next(0, 6), []);
    }
}