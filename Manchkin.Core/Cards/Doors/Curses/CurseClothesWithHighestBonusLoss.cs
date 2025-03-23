namespace Manchkin.Core;

/// <summary>
/// Потеря шмотки с наибольшим бонусом
/// </summary>
public class CurseClothesWithHighestBonusLoss : Curse, ICurse
{
    public CurseClothesWithHighestBonusLoss(string title) : base(title)
    {
    }
    
    public void Curse(Player player)
    {
        var maxBonus = GetHighestBonus(player);
        if (player.Inventory.Head != null && player.Inventory.Head.Bonus == maxBonus)
        {
            player.Inventory.Head = null;
        }

        else if (player.Inventory.Torso != null && player.Inventory.Torso.Bonus == maxBonus)
        {
            player.Inventory.Torso = null;
        }

        else if (player.Inventory.Legs != null && player.Inventory.Legs.Bonus == maxBonus)
        {
            player.Inventory.Legs = null;
        }
        
        else if (player.Inventory.LeftHand != null && player.Inventory.LeftHand.Bonus == maxBonus)
        {
            if (player.Inventory.LeftHand.IsBig)
            {
                player.Inventory.RightHand = null;
            }
            player.Inventory.LeftHand = null;
        }
        
        else if (player.Inventory.RightHand != null && player.Inventory.RightHand.Bonus == maxBonus)
        {
            player.Inventory.RightHand = null;
        }

        else
        {
            foreach (var additional in player.Inventory.Additional)
            {
                if (additional.Bonus != maxBonus) continue;
                player.Inventory.Additional.Remove(additional);
                return;
            }
        }
    }

    private int GetHighestBonus(Player player)
    {
        var highestBonus = 0;
        if (player.Inventory.Head != null && player.Inventory.Head.Bonus > highestBonus)
        {
            highestBonus = player.Inventory.Head.Bonus;
        }

        if (player.Inventory.LeftHand != null && player.Inventory.LeftHand.Bonus > highestBonus)
        {
            highestBonus = player.Inventory.LeftHand.Bonus;
        }

        if (player.Inventory.RightHand != null && player.Inventory.RightHand.Bonus > highestBonus)
        {
            highestBonus = player.Inventory.RightHand.Bonus;
        }

        if (player.Inventory.Torso != null && player.Inventory.Torso.Bonus > highestBonus)
        {
            highestBonus = player.Inventory.Torso.Bonus;
        }

        if (player.Inventory.Legs != null && player.Inventory.Legs.Bonus > highestBonus)
        {
            highestBonus = player.Inventory.Legs.Bonus;
        }
        
        var additionalMaxBonus = player.Inventory.Additional.Max(add => add.Bonus);
        if (additionalMaxBonus > highestBonus)
        {
            highestBonus = additionalMaxBonus;
        }
        
        return highestBonus;
    }
}