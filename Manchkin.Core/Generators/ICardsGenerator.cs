using Manchkin.Core.Cards;

namespace Manchkin.Core.Generators;

public interface ICardsGenerator
{
    T GetCard<T>() where T : ICard;
}