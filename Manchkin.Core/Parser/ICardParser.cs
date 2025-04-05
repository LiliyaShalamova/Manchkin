namespace Manchkin.Core.Parser;

public interface ICardParser<T>
{
    public List<T> Parse();
}