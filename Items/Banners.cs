using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Items
{
    public class ForestBanner : BannerItem
    {
        public override string ShowName => "Forest Banner";
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
            NPCID.Raven,
            NPCID.Ghost,
        };
    }
    public class RainBanner : BannerItem
    {
        public override string ShowName => "Rain Banner";
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
        public override string ShowName => "Desert Banner";
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
        public override string ShowName => "Snow Banner";
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
        public override string ShowName => "Basic Banner";
        public override short[] BannerList => new short[] { };
        public override int[] BannerItemIds => new int[] { 
            ModContent.ItemType<ForestBanner>(),
            ModContent.ItemType<RainBanner>(),
            ModContent.ItemType<DesertBanner>(),
            ModContent.ItemType<SnowBanner>()
        };
        public override short[] AdditionalMobs => new short[] { 
            NPCID.Dandelion
        };
    }

    public class OceanBanner : BannerItem
    {
        public override string ShowName => "Ocean Banner";
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
        public override string ShowName => "Jungle Banner";
        public override short[] BannerList => new short[] {
            ItemID.JungleSlimeBanner,
            ItemID.JungleBatBanner,
            ItemID.SnatcherBanner,
            ItemID.PiranhaBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class CorruptedBanner : BannerItem
    {
        public override string ShowName => "Corrupted Banner";
        public override short[] BannerList => new short[] {
            ItemID.DevourerBanner,
            ItemID.EaterofSoulsBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class CrimsonBanner : BannerItem
    {
        public override string ShowName => "Crimson Banner";
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
        public override string ShowName => "Moderate Banner";
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
        public override string ShowName => "Underground Jungle Banner";
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
        public override string ShowName => "Underground Desert Banner";
        public override short[] BannerList => new short[] {
            ItemID.WalkingAntlionBanner,
            ItemID.FlyingAntlionBanner,
            ItemID.TombCrawlerBanner,
            ItemID.LarvaeAntlionBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class GlowingMushroomBanner : BannerItem
    {
        public override string ShowName => "Glowing Mushroom Banner";
        public override short[] BannerList => new short[] {
            ItemID.SporeZombieBanner,
            ItemID.MushiLadybugBanner,
            ItemID.AnomuraFungusBanner,
            ItemID.SporeBatBanner,
            ItemID.SporeSkeletonBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class CavernBanner : BannerItem
    {
        public override string ShowName => "Cavern Banner";
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
            NPCID.LostGirl,
            NPCID.Salamander,
            NPCID.Tim,
            NPCID.UndeadMiner,
            NPCID.BabySlime,
            NPCID.GiantWormHead,
        };
    }
    public class UndergroundBanner : BannerItem
    {
        public override string ShowName => "Underground Banner";
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
        public override string ShowName => "Blood Moon Banner";
        public override short[] BannerList => new short[] {
            ItemID.BloodZombieBanner,
            ItemID.DripplerBanner,
            ItemID.ZombieMermanBanner,
            ItemID.EyeballFlyingFishBanner
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
        public override string ShowName => "Advanced Banner";
        public override short[] BannerList => new short[] { 
            ItemID.HarpyBanner
        };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<ModerateBanner>(),
            ModContent.ItemType<UndergroundBanner>(),
            ModContent.ItemType<BloodMoonBanner>()
        };
        public override short[] AdditionalMobs => new short[] { 
            NPCID.Gnome
        };
    }

    public class DungeonBanner : BannerItem
    {
        public override string ShowName => "Dungeon Banner";
        public override short[] BannerList => new short[] {
            ItemID.AngryBonesBanner,
            ItemID.CursedSkullBanner,
            ItemID.SkeletonMageBanner,
            ItemID.DungeonSlimeBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.SpikeBall,
            NPCID.BlazingWheel
        };
    }
    public class GoblinArmyBanner : BannerItem
    {
        public override string ShowName => "Goblin Army Banner";
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
    public class OldArmyBanner : BannerItem
    {
        public override string ShowName => "Old One's Army Banner";
        public override short[] BannerList => new short[] {
            ItemID.DD2JavelinThrowerBanner,
            ItemID.DD2GoblinBanner,
            ItemID.DD2GoblinBomberBanner,
            ItemID.DD2WyvernBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.DD2SkeletonT1
        };
    }
    public class UnderworldBanner : BannerItem
    {
        public override string ShowName => "Underworld Banner";
        public override short[] BannerList => new short[] {
            ItemID.LavaSlimeBanner,
            ItemID.HellbatBanner,
            ItemID.BoneSerpentBanner,
            ItemID.DemonBanner,
            ItemID.FireImpBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
        };
    }
    public class ProfessionalBanner : BannerItem
    {
        public override string ShowName => "Professional Banner";
        public override short[] BannerList => new short[] {
            ItemID.MeteorHeadBanner
        };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<AdvancedBanner>(),
            ModContent.ItemType<DungeonBanner>(),
            ModContent.ItemType<GoblinArmyBanner>(),
            ModContent.ItemType<OldArmyBanner>(),
            ModContent.ItemType<UnderworldBanner>()
        };
        public override short[] AdditionalMobs => new short[] { };
    }

    public class HardmodeSurfaceBanner : BannerItem
    {
        public override string ShowName => "Hardmode Surface Banner";
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
            ItemID.SandsharkBanner,
            ItemID.WanderingEyeBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.HoppinJack
        };
    }
    public class HardmodeCavernBanner : BannerItem
    {
        public override string ShowName => "Hardmode Cavern Banner";
        public override short[] BannerList => new short[] {
            ItemID.ToxicSludgeBanner,
            ItemID.ArmoredSkeletonBanner,
            ItemID.GiantBatBanner,
            ItemID.SkeletonArcherBanner,
            ItemID.GreenJellyfishBanner,
            ItemID.BlackRecluseBanner,
            ItemID.FungiBulbBanner,
            ItemID.FungoFishBanner,
            ItemID.RockGolemBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.DiggerHead
        };
    }
    public class HardmodeUndergroundBanner : BannerItem
    {
        public override string ShowName => "Hardmode Underground Banner";
        public override short[] BannerList => new short[] {
            ItemID.ArmoredVikingBanner,
            ItemID.IceTortoiseBanner,
            ItemID.IcyMermanBanner,
            ItemID.AngryTrapperBanner,
            ItemID.TortoiseBanner,
            ItemID.JungleCreeperBanner,
            ItemID.DesertBasiliskBanner,
            ItemID.DuneSplicerBanner,
            ItemID.DesertGhoulBanner,
            ItemID.DesertLamiaBanner,
            ItemID.RavagerScorpionBanner,
            ItemID.MossHornetBanner
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
            NPCID.DesertDjinn
        };
    }
    public class HardmodeCorruptedBanner : BannerItem
    {
        public override string ShowName => "Hardmode Corrupted Banner";
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
            NPCID.SandsharkCorrupt
        };
    }
    public class HardmodeCrimsonBanner : BannerItem
    {
        public override string ShowName => "Hardmode Crimson Banner";
        public override short[] BannerList => new short[] {
            ItemID.HerplingBanner,
            ItemID.CrimslimeBanner,
            ItemID.CrimsonAxeBanner,
            ItemID.FloatyGrossBanner,
            ItemID.IchorStickerBanner,
            ItemID.BloodJellyBanner,
            ItemID.BloodFeederBanner,
            ItemID.BloodMummyBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.SandsharkCrimson
        };
    }
    public class HallowBanner : BannerItem
    {
        public override string ShowName => "Hallow Banner";
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
        public override string ShowName => "Master Banner";
        public override short[] BannerList => new short[] {
            ItemID.BloodNautilusBanner,
            ItemID.BloodSquidBanner,
            ItemID.GoblinSharkBanner,
            ItemID.BloodEelBanner,
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
        };
    }

    public class PirateBanner : BannerItem
    {
        public override string ShowName => "Pirate Banner";
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
        };
    }
    public class UltraBanner : BannerItem
    {
        public override string ShowName => "Ultra Banner";
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
        public override string ShowName => "Temple Banner";
        public override short[] BannerList => new short[] {
            ItemID.FlyingSnakeBanner,
            ItemID.LihzahrdBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class HardmodeDungeonBanner : BannerItem
    {
        public override string ShowName => "Hardmode Dungeon Banner";
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
        public override string ShowName => "Solar Eclipse Banner";
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
        public override string ShowName => "Exceptional Banner";
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
        public override string ShowName => "Martian Banner";
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
    public class OldArmyHardmodeBanner : BannerItem
    {
        public override string ShowName => "Old One's Army Hardmode Banner";
        public override short[] BannerList => new short[] {
            ItemID.DD2DrakinBanner,
            ItemID.DD2LightningBugBanner,
            ItemID.DD2KoboldBanner,
            ItemID.DD2KoboldFlyerBanner,
            ItemID.DD2WitherBeastBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { };
    }
    public class PumpkinMoonBanner : BannerItem
    {
        public override string ShowName => "Pumpkin Moon Banner";
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
        public override string ShowName => "Frost Moon Banner";
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
        public override string ShowName => "Vortex Banner";
        public override short[] BannerList => new short[] {
            ItemID.VortexHornetBanner,
            ItemID.VortexLarvaBanner,
            ItemID.VortexHornetQueenBanner,
            ItemID.VortexRiflemanBanner,
            ItemID.VortexSoldierBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] { 
            NPCID.LunarTowerVortex
        };
    }
    public class StardustBanner : BannerItem
    {
        public override string ShowName => "Stardust Banner";
        public override short[] BannerList => new short[] {
            ItemID.StardustJellyfishBanner,
            ItemID.StardustLargeCellBanner,
            ItemID.StardustSoldierBanner,
            ItemID.StardustSpiderBanner,
            ItemID.StardustWormBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.LunarTowerStardust
        };
    }
    public class NebulaBanner : BannerItem
    {
        public override string ShowName => "Nebula Banner";
        public override short[] BannerList => new short[] {
            ItemID.NebulaBeastBanner,
            ItemID.NebulaBrainBanner,
            ItemID.NebulaHeadcrabBanner,
            ItemID.NebulaSoldierBanner
        };
        public override int[] BannerItemIds => System.Array.Empty<int>();
        public override short[] AdditionalMobs => new short[] {
            NPCID.LunarTowerNebula
        };
    }
    public class SolarBanner : BannerItem
    {
        public override string ShowName => "Solar Banner";
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
            NPCID.LunarTowerSolar
        };
    }
    public class LunarBanner : BannerItem
    {
        public override string ShowName => "Lunar Banner";
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
        public override string ShowName => "The Banner";
        public override short[] BannerList => new short[] { };
        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<ExceptionalBanner>(),
            ModContent.ItemType<MartianBanner>(),
            ModContent.ItemType<OldArmyHardmodeBanner>(),
            ModContent.ItemType<PumpkinMoonBanner>(),
            ModContent.ItemType<FrostMoonBanner>(),
            ModContent.ItemType<LunarBanner>()
        };
        public override short[] AdditionalMobs => new short[] { };
    }

    public class HorrorTrophy : BannerItem
    {
        public override string ShowName => "Horror Trophy";

        public override short[] BannerList => new short[]
        {
            ItemID.EyeofCthulhuTrophy,
            WorldGen.crimson ? ItemID.BrainofCthulhuTrophy : ItemID.EaterofWorldsTrophy,
            ItemID.SkeletronTrophy
        };

        public override int[] BannerItemIds => System.Array.Empty<int>();

        public override short[] AdditionalMobs => new short[] {
            (!WorldGen.crimson) ? NPCID.BrainofCthulhu : NPCID.EaterofWorldsHead,
        };
    }
    public class PreHardmodeTrophy : BannerItem
    {
        public override string ShowName => "Pre Hardmode Trophy";

        public override short[] BannerList => new short[]
        {
            ItemID.WallofFleshTrophy,
            ItemID.KingSlimeTrophy,
            ItemID.QueenBeeTrophy,
            ItemID.BossTrophyDarkmage,
            ItemID.DeerclopsTrophy
        };

        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<HorrorTrophy>(),
        };

        public override short[] AdditionalMobs => new short[] { 
            NPCID.TorchGod
        };
    }
    public class MechanicsTrophy : BannerItem
    {
        public override string ShowName => "Mechanics Trophy";

        public override short[] BannerList => new short[]
        {
            ItemID.DestroyerTrophy,
            ItemID.SpazmatismTrophy,
            ItemID.RetinazerTrophy,
            ItemID.SkeletronPrimeTrophy
        };

        public override int[] BannerItemIds => System.Array.Empty<int>();

        public override short[] AdditionalMobs => new short[] { };
    }
    public class AncientTrophy : BannerItem
    {
        public override string ShowName => "Ancient Trophy";

        public override short[] BannerList => new short[]
        {
            ItemID.QueenSlimeTrophy,
            ItemID.PlanteraTrophy,
            ItemID.GolemTrophy,
            ItemID.FairyQueenTrophy,
            ItemID.DukeFishronTrophy,
            ItemID.AncientCultistTrophy,
            ItemID.MoonLordTrophy
        };

        public override int[] BannerItemIds => System.Array.Empty<int>();

        public override short[] AdditionalMobs => new short[] { };
    }
    public class MoonTrophy : BannerItem
    {
        public override string ShowName => "Moon Trophy";

        public override short[] BannerList => new short[]
        {
            ItemID.MourningWoodTrophy,
            ItemID.PumpkingTrophy,
            ItemID.EverscreamTrophy,
            ItemID.IceQueenTrophy,
            ItemID.SantaNK1Trophy
        };

        public override int[] BannerItemIds => System.Array.Empty<int>();

        public override short[] AdditionalMobs => new short[] { };
    }
    public class EventsTrophy : BannerItem
    {
        public override string ShowName => "Events Trophy";

        public override short[] BannerList => new short[]
        {
            ItemID.FlyingDutchmanTrophy,
            ItemID.MartianSaucerTrophy,
            ItemID.BossTrophyOgre,
            ItemID.BossTrophyBetsy,
            ItemID.MartianSaucerTrophy
        };

        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<MoonTrophy>(),
        };

        public override short[] AdditionalMobs => new short[] { };
    }
    public class TheTrophy : BannerItem
    {
        public override string ShowName => "The Trophy";

        public override short[] BannerList => new short[] { };

        public override int[] BannerItemIds => new int[] {
            ModContent.ItemType<PreHardmodeTrophy>(),
            ModContent.ItemType<MechanicsTrophy>(),
            ModContent.ItemType<AncientTrophy>(),
            ModContent.ItemType<EventsTrophy>(),
        };

        public override short[] AdditionalMobs => new short[] { };
    }
}
