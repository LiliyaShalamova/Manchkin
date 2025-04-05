using Manchkin.Core.Cards.Doors;
using Manchkin.Core.Cards.Doors.Curses;
using Manchkin.Core.Cards.Doors.Monsters;
using Manchkin.Core.Cards.Treasures;
using Manchkin.Core.Cards.Treasures.Clothes;
using Manchkin.Core.Cards.Treasures.Spells;
using Manchkin.Core.Generators.Cards.Doors.Curses;
using Manchkin.Core.Generators.Cards.Doors.Monsters;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Additional;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Shoes;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Smuts;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Vests;
using Manchkin.Core.Generators.Cards.Treasures.Clothes.Weapon;
using Manchkin.Core.Generators.Cards.Treasures.Spells.FightingSpells;
using Manchkin.Core.Generators.Cards.Treasures.Spells.OtherSpells;
using Manchkin.Core.Parser;

namespace Manchkin.Core.Generators;

internal class CardsGenerator<T> : ICardsGenerator<T>
{
    private readonly Random _random = new();

    //private readonly ICardParser<IClothes> _clothesParser = new ClothesParser();
    //private readonly ICardParser<ISpell> _spellParser = new SpellParser();
    //private readonly ICardParser<IMonster> _monsterParser = new MonsterParser();
    //private readonly ICardParser<ICurse> _curseParser = new CurseParser();
    private List<Type> _treasuresCardsTypes =
    [
        typeof(TattooWithWolf), typeof(TrulyImpressiveTitle), typeof(DesignerShoes),
        typeof(FeltBoots), typeof(ProtectiveSandals), typeof(MightyKickBoots), typeof(ReallyFastRunningShoes),
        typeof(ClearBangs), typeof(InvisibilityCap), typeof(PointedHatOfPower), typeof(Ukokoshnik), typeof(Ushanka),
        typeof(FlameArmor), typeof(IronCurtain), typeof(LeatherOutfit), typeof(MithrilArmor), typeof(SportsSuit),
        typeof(ShortVest),
        typeof(Balalaika), typeof(BathBroom), typeof(BrassKnucklesOfUnknownOrigin), typeof(CombatSkewers),
        typeof(EnchantingPipe),
        typeof(Needle), typeof(PancakeBarreledGun), typeof(StringBag), typeof(SwordLollipop), typeof(TheTsarBell),
        typeof(BlankCartridgeFightingSpell), typeof(BorschtPackageFightingSpell), typeof(DeadWaterFightingSpell),
        typeof(FlasherFightingSpell), typeof(HematogenFightingSpell), typeof(HerringUnderFurCoatFightingSpell),
        typeof(MiningFarmFightingSpell), typeof(MolotovCocktailFightingSpell), typeof(ProtectiveSandals),
        typeof(ThePowerOfKsivaFightingSpell), typeof(ZelenkaFightingSpell), typeof(CookPorridgeFromAxeGetLevelOtherSpell),
        typeof(FindRussianTraceGetLevelOtherSpell), typeof(GoToBathhouseGetLevelOtherSpell), typeof(PaintGrassGetLevelOtherSpell),
        typeof(ResolveCubanMissileCrisisGetLevelOtherSpell), typeof(TakeMeteoritePhotoGetLevelOtherSpell),
        typeof(TreasuresBonusOtherSpell), typeof(WantedRingOtherSpell)
    ];

    private List<Type> _doorsCardsTypes = 
    [
        typeof(CurseArmorLoss), typeof(CurseClothesWithHighestBonusLoss), typeof(CursePlayersClassLoss), typeof(CurseShoesLoss),
        typeof(CutOffTheBranchLevelLossCurse), typeof(PaintedLevelLossCurse), typeof(BabaYaga), typeof(IvanTheTerrible),
        typeof(KoscheiTheDeathless), typeof(LittleGreyWolf), typeof(PlayerClassLossMonster), typeof(ShoesLossMonster),
        typeof(Viy)
    ];

    private List<T> Deck { get; }

    public CardsGenerator()
    {
        Deck = [];
        GenerateDeck();
    }

    public T GetCard()
    {
        return GetGenerator().First();
    }

    private IEnumerable<T> GetGenerator()
    {
        while (true)
        {
            yield return Deck[_random.Next(0, Deck.Count)];
        }
    }

    private void GenerateDeck()
    {
        if (typeof(T) == typeof(IDoor))
        {
            foreach (var type in _doorsCardsTypes)
            {
                Deck.Add((T)Activator.CreateInstance(type));
            }
        }

        if (typeof(T) == typeof(ITreasure))
        {
            foreach (var type in _treasuresCardsTypes)
            {
                Deck.Add((T)Activator.CreateInstance(type));
            }
        }
    }
/*
    private void GenerateDoors()
    {
        GenerateCurses();
        GenerateRaces();
        GeneratePlayerClasses();
        GenerateMonsters();
    }

    private void GenerateCurses()
    {
        Deck.AddRange((IEnumerable<T>)_curseParser.Parse());
    }

    private void GenerateRaces()
    {
        //const string racesPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\Races.txt";
        //Deck.AddRange((IEnumerable<T>)_cardsParser.ParseByDelimiters<Race>(racesPath, ";", ["/*"]));
    }

    private void GeneratePlayerClasses()
    {
        //const string playerClassPath = @"C:\Users\shala\source\repos\Манчкин\Manchkin\Manchkin.Core\Cards\CardsFiles\PlayerClasses.txt";
        //Deck.AddRange((IEnumerable<T>)_cardsParser.ParseByDelimiters<PlayerClass>(playerClassPath, ";", ["/*"]));
    }

    private void GenerateMonsters()
    {
        Deck.AddRange((IEnumerable<T>)_monsterParser.Parse());
    }

    private void GenerateTreasures()
    {
        GenerateClothes();
        GenerateSpells();
    }

    private void GenerateClothes()
    {
        Deck.AddRange((IEnumerable<T>)_clothesParser.Parse());
    }

    private void GenerateSpells()
    {
        Deck.AddRange((IEnumerable<T>)_spellParser.Parse());
    }*/
}