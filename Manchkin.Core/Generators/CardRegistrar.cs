using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Generators.Cards.Doors.Curses;
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
        _cardsStorage.RegisterClothes<TattooWithWolf>();
        _cardsStorage.RegisterClothes<TrulyImpressiveTitle>();
        _cardsStorage.RegisterClothes<DesignerShoes>();
        _cardsStorage.RegisterClothes<FeltBoots>();
        _cardsStorage.RegisterClothes<ProtectiveSandals>();
        _cardsStorage.RegisterClothes<MightyKickBoots>();
        _cardsStorage.RegisterClothes<ReallyFastRunningShoes>();
        _cardsStorage.RegisterClothes<ClearBangs>();
        _cardsStorage.RegisterClothes<InvisibilityCap>();
        _cardsStorage.RegisterClothes<PointedHatOfPower>();
        _cardsStorage.RegisterClothes<Ukokoshnik>();
        _cardsStorage.RegisterClothes<Ushanka>();
        _cardsStorage.RegisterClothes<FlameArmor>();
        _cardsStorage.RegisterClothes<IronCurtain>();
        _cardsStorage.RegisterClothes<LeatherOutfit>();
        _cardsStorage.RegisterClothes<MithrilArmor>();
        _cardsStorage.RegisterClothes<SportsSuit>();
        _cardsStorage.RegisterClothes<ShortVest>();
        _cardsStorage.RegisterClothes<Balalaika>();
        _cardsStorage.RegisterClothes<BathBroom>();
        _cardsStorage.RegisterClothes<BrassKnucklesOfUnknownOrigin>();
        _cardsStorage.RegisterClothes<CombatSkewers>();
        _cardsStorage.RegisterClothes<EnchantingPipe>();
        _cardsStorage.RegisterClothes<Needle>();
        _cardsStorage.RegisterClothes<PancakeBarreledGun>();
        _cardsStorage.RegisterClothes<StringBag>();
        _cardsStorage.RegisterClothes<SwordLollipop>();
        _cardsStorage.RegisterClothes<TheTsarBell>();
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