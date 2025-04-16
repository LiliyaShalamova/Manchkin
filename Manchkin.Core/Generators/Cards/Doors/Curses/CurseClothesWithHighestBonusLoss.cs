using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Players;

namespace Manchkin.Core.Generators.Cards.Doors.Curses;

/// <summary>
/// Потеря шмотки с наибольшим бонусом
/// </summary>
internal class CurseClothesWithHighestBonusLoss : ICurse
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Title => "Сдаём на подарки! Потеряй шмотку с наибольшим бонусом";

    /// <summary>
    /// Разовое или действует до определенного момента. На будущее
    /// </summary>
    public bool OneTimeCurse { get; init; } = true;
    
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
                player.Inventory.Additional = player.Inventory.Additional.Remove(additional);
                return;
            }
        }
    }

    private int GetHighestBonus(PublicPlayer player)
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
        
        var additionalMaxBonus = player.Inventory.Additional.Count > 0 ? player.Inventory.Additional.Max(add => add.Bonus) : 0;
        if (additionalMaxBonus > highestBonus)
        {
            highestBonus = additionalMaxBonus;
        }
        
        return highestBonus;
    }
}