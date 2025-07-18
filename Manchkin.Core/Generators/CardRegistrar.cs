﻿using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;

namespace Manchkin.Core.Generators;

internal class CardRegistrar : ICardRegistrar
{
    private readonly CardsStorage _cardsStorage;

    public CardRegistrar(CardsStorage cardsStorage)
    {
        _cardsStorage = cardsStorage;
    }
    public void Register()
    {
        RegisterClothes();
        RegisterFightingSpells();
        RegisterOtherSpells();
        RegisterCurses();
        RegisterMonsters();
    }
    
    private void RegisterClothes()
    {
        _cardsStorage.RegisterAdditionalClothes<TattooWithWolf>();
        _cardsStorage.RegisterAdditionalClothes<TrulyImpressiveTitle>();
        _cardsStorage.RegisterShoes<DesignerShoes>();
        _cardsStorage.RegisterShoes<FeltBoots>();
        _cardsStorage.RegisterShoes<ProtectiveSandals>();
        _cardsStorage.RegisterShoes<MightyKickBoots>();
        _cardsStorage.RegisterShoes<ReallyFastRunningShoes>();
        _cardsStorage.RegisterSmut<ClearBangs>();
        _cardsStorage.RegisterSmut<InvisibilityCap>();
        _cardsStorage.RegisterSmut<PointedHatOfPower>();
        _cardsStorage.RegisterSmut<Ukokoshnik>();
        _cardsStorage.RegisterSmut<Ushanka>();
        _cardsStorage.RegisterVest<FlameArmor>();
        _cardsStorage.RegisterVest<IronCurtain>();
        _cardsStorage.RegisterVest<LeatherOutfit>();
        _cardsStorage.RegisterVest<MithrilArmor>();
        _cardsStorage.RegisterVest<SportsSuit>();
        _cardsStorage.RegisterVest<ShortVest>();
        _cardsStorage.RegisterWeapon<Balalaika>();
        _cardsStorage.RegisterWeapon<BathBroom>();
        _cardsStorage.RegisterWeapon<BrassKnucklesOfUnknownOrigin>();
        _cardsStorage.RegisterWeapon<CombatSkewers>();
        _cardsStorage.RegisterWeapon<EnchantingPipe>();
        _cardsStorage.RegisterWeapon<Needle>();
        _cardsStorage.RegisterWeapon<PancakeBarreledGun>();
        _cardsStorage.RegisterWeapon<StringBag>();
        _cardsStorage.RegisterWeapon<SwordLollipop>();
        _cardsStorage.RegisterWeapon<TheTsarBell>();
    }

    private void RegisterFightingSpells()
    {
        _cardsStorage.RegisterFightingSpell<BlankCartridgeFightingSpell>();
        _cardsStorage.RegisterFightingSpell<BorschtPackageFightingSpell>();
        _cardsStorage.RegisterFightingSpell<DeadWaterFightingSpell>();
        _cardsStorage.RegisterFightingSpell<FlasherFightingSpell>();
        _cardsStorage.RegisterFightingSpell<HematogenFightingSpell>();
        _cardsStorage.RegisterFightingSpell<HerringUnderFurCoatFightingSpell>();
        _cardsStorage.RegisterFightingSpell<MiningFarmFightingSpell>();
        _cardsStorage.RegisterFightingSpell<MolotovCocktailFightingSpell>();
        _cardsStorage.RegisterFightingSpell<ThePowerOfKsivaFightingSpell>();
        _cardsStorage.RegisterFightingSpell<ZelenkaFightingSpell>();
    }

    private void RegisterOtherSpells()
    {
        _cardsStorage.RegisterOtherSpell<CookPorridgeFromAxeGetLevelOtherSpell>();
        _cardsStorage.RegisterOtherSpell<FindRussianTraceGetLevelOtherSpell>();
        _cardsStorage.RegisterOtherSpell<GoToBathhouseGetLevelOtherSpell>();
        _cardsStorage.RegisterOtherSpell<PaintGrassGetLevelOtherSpell>();
        _cardsStorage.RegisterOtherSpell<ResolveCubanMissileCrisisGetLevelOtherSpell>();
        _cardsStorage.RegisterOtherSpell<TakeMeteoritePhotoGetLevelOtherSpell>();
        _cardsStorage.RegisterOtherSpell<TreasuresBonusOtherSpell>();
        _cardsStorage.RegisterOtherSpell<WantedRingOtherSpell>();
    }

    private void RegisterMonsters()
    {
        _cardsStorage.RegisterMonster<BabaYaga>();
        _cardsStorage.RegisterMonster<IvanTheTerrible>();
        _cardsStorage.RegisterMonster<KoscheiTheDeathless>();
        _cardsStorage.RegisterMonster<LittleGreyWolf>();
        _cardsStorage.RegisterMonster<PlayerClassLossMonster>();
        _cardsStorage.RegisterMonster<ShoesLossMonster>();
        _cardsStorage.RegisterMonster<Viy>();
    }

    private void RegisterCurses()
    {
        _cardsStorage.RegisterCurse<CurseArmorLoss>();
        _cardsStorage.RegisterCurse<CurseClothesWithHighestBonusLoss>();
        _cardsStorage.RegisterCurse<CursePlayersClassLoss>();
        _cardsStorage.RegisterCurse<CurseShoesLoss>();
        _cardsStorage.RegisterCurse<CutOffTheBranchLevelLossCurse>();
        _cardsStorage.RegisterCurse<PaintedLevelLossCurse>();
    }
}