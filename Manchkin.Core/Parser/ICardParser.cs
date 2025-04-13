namespace Manchkin.Core.Parser;

public interface ICardParser<T>
{ 
    List<T> Parse();
}