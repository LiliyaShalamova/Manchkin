using Manchkin.Core.Cards.Treasures.Spells;

namespace Manchkin.Core;

public class CurseArmorLoss : Curse, ICurse // TODO наследуем от curse или door?
{
    public CurseArmorLoss(string title) : base(title)
    {
    }
    
    public void Curse(Player player)
    {
        player.Inventory.Torso = null; // прям там затираем или надо чтобы одежка была приватной и через публичный метод выкидываем шмотку?
    }
}
