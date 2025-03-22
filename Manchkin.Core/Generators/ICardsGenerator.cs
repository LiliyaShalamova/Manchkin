namespace Manchkin.Core.Generators;

public interface ICardsGenerator<T>
{
    public T GetCard();
}