namespace Manchkin.Core; 

/// <summary>
/// Класс игры
/// </summary>
public class Game
{
    private int _levelsNumber = 10;
    public Player[] Players { get; set; }
    public Door[] Doors { get; set; }
    public Treasure[] Treasures { get; set; }
    public Door[] DoorsReset { get; set; }
    public Treasure[] TreasuresReset { get; set; }
}