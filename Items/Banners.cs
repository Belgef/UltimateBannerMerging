using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Items
{
    public class ForestBanner : BannerItem
    {
        public override string ShowName => "Forest";
        public override short[] BannerList => new short[] { 
            ItemID.GreenSlimeBanner, 
            ItemID.SlimeBanner, 
            ItemID.PurpleSlimeBanner, 
            ItemID.ZombieBanner, 
            ItemID.DemonEyeBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.Pinky, 
            NPCID.GoblinScout,
            NPCID.SlimeRibbonGreen,
            NPCID.SlimeRibbonRed,
            NPCID.SlimeRibbonWhite,
            NPCID.SlimeRibbonYellow,
            NPCID.SlimeMasked,
            NPCID.Raven,
            NPCID.Ghost,
        };
    }
    public class RainBanner : BannerItem
    {
        public override string ShowName => "Rain";
        public override short[] BannerList => new short[] {
            ItemID.UmbrellaSlimeBanner,
            ItemID.FlyingFishBanner,
            ItemID.RaincoatZombieBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class DesertBanner : BannerItem
    {
        public override string ShowName => "Desert";
        public override short[] BannerList => new short[] {
            ItemID.SandSlimeBanner,
            ItemID.AntlionBanner,
            ItemID.VultureBanner,
            ItemID.TumbleweedBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class SnowBanner : BannerItem
    {
        public override string ShowName => "Snow";
        public override short[] BannerList => new short[] {
            ItemID.IceSlimeBanner,
            ItemID.IceBatBanner,
            ItemID.ZombieEskimoBanner,
            ItemID.SpikedIceSlimeBanner,
            ItemID.SnowFlinxBanner,
            ItemID.UndeadVikingBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.CyanBeetle
        };
    }
    public class BasicBanner : BannerItem
    {
        public override string ShowName => "Basic";
        public override short[] BannerList => new short[] { };
        public override int[] BannerItemIds => new int[] { 
            ModContent.ItemType<ForestBanner>(),
            ModContent.ItemType<RainBanner>(),
            ModContent.ItemType<DesertBanner>(),
            ModContent.ItemType<SnowBanner>()
        };
        public override short[] AdditionalMobs => new short[] { };
    }

    public class OceanBanner : BannerItem
    {
        public override string ShowName => "Ocean";
        public override short[] BannerList => new short[] {
            ItemID.CrabBanner,
            ItemID.PinkJellyfishBanner,
            ItemID.SeaSnailBanner,
            ItemID.SharkBanner,
            ItemID.SquidBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class JungleBanner : BannerItem
    {
        public override string ShowName => "Jungle";
        public override short[] BannerList => new short[] {
            ItemID.JungleSlimeBanner,
            ItemID.JungleBatBanner,
            ItemID.SnatcherBanner,
            ItemID.PiranhaBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.Bee
        };
    }
    public class CorruptedBanner : BannerItem
    {
        public override string ShowName => "Corrupted";
        public override short[] BannerList => new short[] {
            ItemID.DevourerBanner,
            ItemID.EaterofSoulsBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class CrimsonBanner : BannerItem
    {
        public override string ShowName => "Crimson";
        public override short[] BannerList => new short[] {
            ItemID.BloodCrawlerBanner,
            ItemID.CrimeraBanner,
            ItemID.FaceMonsterBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class ModerateBanner : BannerItem
    {
        public override string ShowName => "Moderate";
        public override short[] BannerList => new short[] { };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<BasicBanner>(),
            WorldGen.crimson ? ModContent.ItemType<CrimsonBanner>() : ModContent.ItemType<CorruptedBanner>(),
            ModContent.ItemType<OceanBanner>(),
            ModContent.ItemType<JungleBanner>()
        };
        public override short[] AdditionalMobs => new short[] { };
    }

    public class UndergroundJungleBanner : BannerItem
    {
        public override string ShowName => "Underground Jungle";
        public override short[] BannerList => new short[] {
            ItemID.ManEaterBanner,
            ItemID.SpikedJungleSlimeBanner,
            ItemID.HornetBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.DoctorBones,
            NPCID.LacBeetle
        };
    }
    public class UndergroundDesertBanner : BannerItem
    {
        public override string ShowName => "Underground Desert";
        public override short[] BannerList => new short[] {
            ItemID.WalkingAntlionBanner,
            ItemID.FlyingAntlionBanner,
            ItemID.TombCrawlerBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class GlowingMushroomBanner : BannerItem
    {
        public override string ShowName => "Glowing Mushroom";
        public override short[] BannerList => new short[] {
            ItemID.SporeZombieBanner,
            ItemID.MushiLadybugBanner,
            ItemID.AnomuraFungusBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class CavernBanner : BannerItem
    {
        public override string ShowName => "Cavern";
        public override short[] BannerList => new short[] {
            ItemID.RedSlimeBanner,
            ItemID.YellowSlimeBanner,
            ItemID.BatBanner,
            ItemID.BlackSlimeBanner,
            ItemID.MotherSlimeBanner,
            ItemID.SkeletonBanner,
            ItemID.JellyfishBanner,
            ItemID.SpiderBanner,
            ItemID.GraniteFlyerBanner,
            ItemID.GraniteGolemBanner,
            ItemID.GreekSkeletonBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.CochinealBeetle,
            NPCID.Crawdad,
            NPCID.GiantShelly,
            NPCID.Worm,
            NPCID.Nymph,
            NPCID.Salamander,
            NPCID.Tim,
            NPCID.UndeadMiner,
            NPCID.BabySlime,
            NPCID.GiantWormHead,
        };
    }
    public class UndergroundBanner : BannerItem
    {
        public override string ShowName => "Underground";
        public override short[] BannerList => new short[] { };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<CavernBanner>(),
            ModContent.ItemType<GlowingMushroomBanner>(),
            ModContent.ItemType<UndergroundDesertBanner>(),
            ModContent.ItemType<UndergroundJungleBanner>()
        };
        public override short[] AdditionalMobs => new short[] { };
    }
    public class BloodMoonBanner : BannerItem
    {
        public override string ShowName => "Blood Moon";
        public override short[] BannerList => new short[] {
            ItemID.BloodZombieBanner,
            ItemID.DripplerBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.CorruptBunny,
            NPCID.CorruptGoldfish,
            NPCID.CorruptPenguin,
            NPCID.TheGroom,
            NPCID.TheBride,
            NPCID.CrimsonBunny,
            NPCID.CrimsonPenguin,
            NPCID.CrimsonGoldfish
        };
    }
    public class AdvancedBanner : BannerItem
    {
        public override string ShowName => "Advanced";
        public override short[] BannerList => new short[] { 
            ItemID.HarpyBanner
        };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<ModerateBanner>(),
            ModContent.ItemType<UndergroundBanner>(),
            ModContent.ItemType<BloodMoonBanner>()
        };
        public override short[] AdditionalMobs => new short[] { };
    }

    public class DungeonBanner : BannerItem
    {
        public override string ShowName => "Dungeon";
        public override short[] BannerList => new short[] {
            ItemID.AngryBonesBanner,
            ItemID.CursedSkullBanner,
            ItemID.SkeletonMageBanner,
            ItemID.DungeonSlimeBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class GoblinArmyBanner : BannerItem
    {
        public override string ShowName => "Goblin Army";
        public override short[] BannerList => new short[] {
            ItemID.GoblinArcherBanner,
            ItemID.GoblinPeonBanner,
            ItemID.GoblinSorcererBanner,
            ItemID.GoblinThiefBanner,
            ItemID.GoblinWarriorBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class UnderworldBanner : BannerItem
    {
        public override string ShowName => "Underworld";
        public override short[] BannerList => new short[] {
            ItemID.LavaSlimeBanner,
            ItemID.HellbatBanner,
            ItemID.BoneSerpentBanner,
            ItemID.DemonBanner,
            ItemID.FireImpBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.VoodooDemon
        };
    }
    public class ProfessionalBanner : BannerItem
    {
        public override string ShowName => "Professional";
        public override short[] BannerList => new short[] {
            ItemID.MeteorHeadBanner
        };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<AdvancedBanner>(),
            ModContent.ItemType<DungeonBanner>(),
            ModContent.ItemType<GoblinArmyBanner>(),
            ModContent.ItemType<UnderworldBanner>()
        };
        public override short[] AdditionalMobs => new short[] { };
    }

    public class HardmodeSurfaceBanner : BannerItem
    {
        public override string ShowName => "Hardmode Surface";
        public override short[] BannerList => new short[] {
            ItemID.PossessedArmorBanner,
            ItemID.WraithBanner,
            ItemID.WerewolfBanner,
            ItemID.IceElementalBanner,
            ItemID.WolfBanner,
            ItemID.DerplingBanner,
            ItemID.GiantFlyingFoxBanner,
            ItemID.ArapaimaBanner,
            ItemID.MummyBanner,
            ItemID.AngryNimbusBanner,
            ItemID.SandsharkBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.HoppinJack,
            NPCID.WanderingEye
        };
    }
    public class HardmodeCavernBanner : BannerItem
    {
        public override string ShowName => "Hardmode Cavern";
        public override short[] BannerList => new short[] {
            ItemID.ToxicSludgeBanner,
            ItemID.ArmoredSkeletonBanner,
            ItemID.GiantBatBanner,
            ItemID.SkeletonArcherBanner,
            ItemID.GreenJellyfishBanner,
            ItemID.BlackRecluseBanner,
            ItemID.FungiBulbBanner,
            ItemID.FungoFishBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.DiggerHead
        };
    }
    public class HardmodeUndergroundBanner : BannerItem
    {
        public override string ShowName => "Hardmode Underground";
        public override short[] BannerList => new short[] {
            ItemID.ArmoredVikingBanner,
            ItemID.IceTortoiseBanner,
            ItemID.IcyMermanBanner,
            ItemID.AngryTrapperBanner,
            ItemID.TortoiseBanner,
            ItemID.JungleCreeperBanner,
            ItemID.DesertBasiliskBanner,
            ItemID.DesertDjinnBanner,
            ItemID.DuneSplicerBanner,
            ItemID.DesertGhoulBanner,
            ItemID.DesertLamiaBanner,
            ItemID.RavagerScorpionBanner,
        };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<HardmodeCavernBanner>()
        };
        public override short[] AdditionalMobs => new short[] {
            NPCID.RuneWizard,
            NPCID.AnglerFish,
            NPCID.Medusa,
            NPCID.PigronCorruption,
            NPCID.PigronCrimson,
            NPCID.PigronHallow,
            NPCID.Moth,
            NPCID.DesertGhoulCorruption,
            NPCID.DesertGhoulCrimson,
            NPCID.DesertGhoulHallow,
            NPCID.MossHornet
        };
    }
    public class HardmodeCorruptedBanner : BannerItem
    {
        public override string ShowName => "Hardmode Corrupted";
        public override short[] BannerList => new short[] {
            ItemID.CorruptSlimeBanner,
            ItemID.SlimerBanner,
            ItemID.CorruptorBanner,
            ItemID.DarkMummyBanner,
            ItemID.WorldFeederBanner,
            ItemID.ClingerBanner,
            ItemID.CursedHammerBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.SandsharkCorrupt,
            NPCID.Slimeling
        };
    }
    public class HardmodeCrimsonBanner : BannerItem
    {
        public override string ShowName => "Hardmode Crimson";
        public override short[] BannerList => new short[] {
            ItemID.HerplingBanner,
            ItemID.CrimslimeBanner,
            ItemID.CrimsonAxeBanner,
            ItemID.FloatyGrossBanner,
            ItemID.IchorStickerBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.SandsharkCrimson,
            NPCID.BloodJelly,
            NPCID.BloodFeeder
        };
    }
    public class HallowBanner : BannerItem
    {
        public override string ShowName => "Hallow";
        public override short[] BannerList => new short[] {
            ItemID.PixieBanner,
            ItemID.UnicornBanner,
            ItemID.GastropodBanner,
            ItemID.LightMummyBanner,
            ItemID.ChaosElementalBanner,
            ItemID.EnchantedSwordBanner,
            ItemID.IlluminantBatBanner,
            ItemID.IlluminantSlimeBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.SandsharkHallow,
            NPCID.RainbowSlime
        };
    }
    public class MasterBanner : BannerItem
    {
        public override string ShowName => "Master";
        public override short[] BannerList => new short[] {
            ItemID.ClownBanner,
            ItemID.GoblinSummonerBanner
        };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<ProfessionalBanner>(),
            ModContent.ItemType<HardmodeSurfaceBanner>(),
            ModContent.ItemType<HardmodeUndergroundBanner>(),
            WorldGen.crimson ? ModContent.ItemType<HardmodeCrimsonBanner>() : ModContent.ItemType<HardmodeCorruptedBanner>(),
            ModContent.ItemType<HallowBanner>(),
        };
        public override short[] AdditionalMobs => new short[] { 
            NPCID.ShadowFlameApparition
        };
    }

    public class PirateBanner : BannerItem
    {
        public override string ShowName => "Pirate";
        public override short[] BannerList => new short[] {
            ItemID.ParrotBanner,
            ItemID.PirateCaptainBanner,
            ItemID.PirateCorsairBanner,
            ItemID.PirateCrossbowerBanner,
            ItemID.PirateDeadeyeBanner,
            ItemID.PirateBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.PirateDeckhand
        };
    }
    public class UltraBanner : BannerItem
    {
        public override string ShowName => "Ultra";
        public override short[] BannerList => new short[] {
            ItemID.MimicBanner,
            ItemID.IceGolemBanner,
            ItemID.SandElementalBanner,
            ItemID.WyvernBanner,
            ItemID.LavaBatBanner,
            ItemID.RedDevilBanner
        };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<MasterBanner>(),
            WorldGen.crimson ? ModContent.ItemType<CorruptedBanner>() : ModContent.ItemType<CrimsonBanner>(),
            WorldGen.crimson ? ModContent.ItemType<HardmodeCorruptedBanner>() : ModContent.ItemType<HardmodeCrimsonBanner>(),
            ModContent.ItemType<PirateBanner>()
        };
        public override short[] AdditionalMobs => new short[] { 
            NPCID.BigMimicCorruption,
            NPCID.BigMimicCrimson,
            NPCID.BigMimicHallow,
            NPCID.DemonTaxCollector
        };
    }

    public class TempleBanner : BannerItem
    {
        public override string ShowName => "Temple";
        public override short[] BannerList => new short[] {
            ItemID.FlyingSnakeBanner,
            ItemID.LihzahrdBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class HardmodeDungeonBanner : BannerItem
    {
        public override string ShowName => "Hardmode Dungeon";
        public override short[] BannerList => new short[] {
            ItemID.BlueArmoredBonesBanner,
            ItemID.RustyArmoredBonesBanner,
            ItemID.HellArmoredBonesBanner,
            ItemID.DiablolistBanner,
            ItemID.NecromancerBanner,
            ItemID.RaggedCasterBanner,
            ItemID.BoneLeeBanner,
            ItemID.SkeletonCommandoBanner,
            ItemID.SkeletonSniperBanner,
            ItemID.TacticalSkeletonBanner,
            ItemID.DungeonSpiritBanner,
            ItemID.GiantCursedSkullBanner,
            ItemID.PaladinBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class SolarEclipseBanner : BannerItem
    {
        public override string ShowName => "Solar Eclipse";
        public override short[] BannerList => new short[] {
            ItemID.ButcherBanner,
            ItemID.CreatureFromTheDeepBanner,
            ItemID.DeadlySphereBanner,
            ItemID.DrManFlyBanner,
            ItemID.EyezorBanner,
            ItemID.FrankensteinBanner,
            ItemID.FritzBanner,
            ItemID.MothronBanner,
            ItemID.NailheadBanner,
            ItemID.PsychoBanner,
            ItemID.ReaperBanner,
            ItemID.SwampThingBanner,
            ItemID.ThePossessedBanner,
            ItemID.VampireBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.MothronSpawn,
            NPCID.VampireBat
        };
    }
    public class ExceptionalBanner : BannerItem
    {
        public override string ShowName => "Exceptional";
        public override short[] BannerList => new short[] { };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<UltraBanner>(),
            ModContent.ItemType<TempleBanner>(),
            ModContent.ItemType<HardmodeDungeonBanner>(),
            ModContent.ItemType<SolarEclipseBanner>()
        };
        public override short[] AdditionalMobs => new short[] { };
    }

    public class MartianBanner : BannerItem
    {
        public override string ShowName => "Martian";
        public override short[] BannerList => new short[] {
            ItemID.MartianBrainscramblerBanner,
            ItemID.MartianDroneBanner,
            ItemID.MartianEngineerBanner,
            ItemID.MartianGigazapperBanner,
            ItemID.MartianGreyGruntBanner,
            ItemID.MartianOfficerBanner,
            ItemID.MartianRaygunnerBanner,
            ItemID.MartianScutlixGunnerBanner,
            ItemID.MartianTeslaTurretBanner,
            ItemID.MartianWalkerBanner,
            ItemID.ScutlixBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class PumpkinMoonBanner : BannerItem
    {
        public override string ShowName => "Pumpkin Moon";
        public override short[] BannerList => new short[] {
            ItemID.HeadlessHorsemanBanner,
            ItemID.HellhoundBanner,
            ItemID.PoltergeistBanner,
            ItemID.ScarecrowBanner,
            ItemID.SplinterlingBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class FrostMoonBanner : BannerItem
    {
        public override string ShowName => "Frost Moon";
        public override short[] BannerList => new short[] {
            ItemID.ElfArcherBanner,
            ItemID.ElfCopterBanner,
            ItemID.FlockoBanner,
            ItemID.GingerbreadManBanner,
            ItemID.KrampusBanner,
            ItemID.NutcrackerBanner,
            ItemID.PresentMimicBanner,
            ItemID.YetiBanner,
            ItemID.ZombieElfBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class VortexBanner : BannerItem
    {
        public override string ShowName => "Vortex";
        public override short[] BannerList => new short[] {
            ItemID.VortexHornetBanner,
            ItemID.VortexLarvaBanner,
            ItemID.VortexHornetQueenBanner,
            ItemID.VortexRiflemanBanner,
            ItemID.VortexSoldierBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class StardustBanner : BannerItem
    {
        public override string ShowName => "Stardust";
        public override short[] BannerList => new short[] {
            ItemID.StardustJellyfishBanner,
            ItemID.StardustLargeCellBanner,
            ItemID.StardustSoldierBanner,
            ItemID.StardustSpiderBanner,
            ItemID.StardustWormBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.StardustSpiderSmall
        };
    }
    public class NebulaBanner : BannerItem
    {
        public override string ShowName => "Nebula";
        public override short[] BannerList => new short[] {
            ItemID.NebulaBeastBanner,
            ItemID.NebulaBrainBanner,
            ItemID.NebulaHeadcrabBanner,
            ItemID.NebulaSoldierBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class SolarBanner : BannerItem
    {
        public override string ShowName => "Solar";
        public override short[] BannerList => new short[] {
            ItemID.SolarCoriteBanner,
            ItemID.SolarCrawltipedeBanner,
            ItemID.SolarDrakomireBanner,
            ItemID.SolarDrakomireRiderBanner,
            ItemID.SolarSolenianBanner,
            ItemID.SolarSrollerBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.SolarSpearman
        };
    }
    public class LunarBanner : BannerItem
    {
        public override string ShowName => "Lunar";
        public override short[] BannerList => new short[] { };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<SolarBanner>(),
            ModContent.ItemType<VortexBanner>(),
            ModContent.ItemType<StardustBanner>(),
            ModContent.ItemType<NebulaBanner>()
        };
        public override short[] AdditionalMobs => new short[] { 
            NPCID.CultistArcherBlue,
            NPCID.CultistArcherWhite
        };
    }
    public class TheBanner : BannerItem
    {
        public override string ShowName => "The";
        public override short[] BannerList => new short[] { };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<ExceptionalBanner>(),
            ModContent.ItemType<MartianBanner>(),
            ModContent.ItemType<PumpkinMoonBanner>(),
            ModContent.ItemType<FrostMoonBanner>(),
            ModContent.ItemType<LunarBanner>()
        };
        public override short[] AdditionalMobs => new short[] { };
    }
}
