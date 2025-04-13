using Manchkin.Core;
using Manchkin.Core.Cards;
using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Extensions.ClothesExtensions;
using Manchkin.Extensions.CurseExtensions;
using Manchkin.Extensions.MonsterExtensions;
using Manchkin.Extensions.SpellExtensions;

namespace Manchkin.Extensions;

public static class CardExtension
{
    public static void Print(this ICard card)
    {
        switch (card)
        {
            case IMonster monster:
                MonsterExtension.Print(monster);
                break;
            case IWeapon weapon:
                WeaponExtension.Print(weapon);
                break;
            case IClothes clothes:
                ClothesExtension.Print(clothes);
                break;
            case ICurse curse:
                CurseExtension.Print(curse);
                break;
            case ISpell spell:
                SpellExtension.Print(spell);
                break;
        }
    }
}