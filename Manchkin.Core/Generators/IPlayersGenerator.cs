using System.CodeDom.Compiler;

namespace Manchkin.Core;

public interface IPlayersGenerator
{
    public Player[] Generate(int playersCount);
}