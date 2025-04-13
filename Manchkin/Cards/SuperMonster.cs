using Manchkin.Core;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators;
using Manchkin.Core.Player;
using Manchkin.Core.Players;

namespace Manchkin.Cards;

public class SuperMonster : IMonster
{
    public string Title { get; init; } = "Супер Монстрррр";
    public int Level => 30;
    public int TreasuresCount => 10;
    public int LevelsCount => 3;
    public int DoesNotFightLevel => 5;

    public void Punish(Player player)
    {
        player.DecreaseLevel(player.Level);
    }

    public SuperMonster()
    {
        
    }
    
    public string Description => "При проигрыше возвращение на уровень 1";
}