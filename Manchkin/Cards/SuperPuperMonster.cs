using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Cards;

public class SuperPuperMonster : IMonster
{
    public string Title { get; init; } = "Супер Пупер Монстрррр";
    public int Level => 30;
    public int TreasuresCount => 10;
    public int LevelsCount => 3;
    public int DoesNotFightLevel => 5;

    public void Punish(Player player)
    {
        player.DecreaseLevel(player.Level);
    }

    public SuperPuperMonster()
    {
        
    }
    
    public string Description => "При проигрыше возвращение на уровень 1";
    
}