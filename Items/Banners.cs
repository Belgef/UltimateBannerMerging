﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { 
            ItemID.PinkyBanner, 
            ItemID.GoblinScoutBanner 
        };
        public override int Price => 10000;
        public override int Multiplyer => 3;
    }
    public class RainBanner : BannerItem
    {
        public override string ShowName => "Rain";
        public override short[] BannerList => new short[] {
            ItemID.UmbrellaSlimeBanner,
            ItemID.FlyingFishBanner,
            ItemID.RaincoatZombieBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 10000;
        public override int Multiplyer => 3;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 10000;
        public override int Multiplyer => 3;
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
            ItemID.ArmoredVikingBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] {
            ItemID.CyanBeetleBanner
        };
        public override int Price => 30000;
        public override int Multiplyer => 5;
    }
    public class BasicBanner : BannerItem
    {
        public override string ShowName => "Basic";
        public override short[] BannerList => new short[] { };
        public override string[] BannerItemNames => new string[] { 
            nameof(ForestBanner),
            nameof(RainBanner),
            nameof(DesertBanner),
            nameof(SnowBanner)
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 100000;
        public override int Multiplyer => 10;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 20000;
        public override int Multiplyer => 3;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 30000;
        public override int Multiplyer => 5;
    }
    public class CorruptedBanner : BannerItem
    {
        public override string ShowName => "Corrupted";
        public override short[] BannerList => new short[] {
            ItemID.DevourerBanner,
            ItemID.EaterofSoulsBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 30000;
        public override int Multiplyer => 5;
    }
    public class CrimsonBanner : BannerItem
    {
        public override string ShowName => "Crimson";
        public override short[] BannerList => new short[] {
            ItemID.BloodCrawlerBanner,
            ItemID.CrimeraBanner,
            ItemID.FaceMonsterBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 30000;
        public override int Multiplyer => 5;
    }
    public class ModerateBanner : BannerItem
    {
        public override string ShowName => "Moderate";
        public override short[] BannerList => new short[] { };
        public override string[] BannerItemNames => new string[] {
            nameof(BasicBanner),
            WorldGen.crimson ? nameof(CrimsonBanner) : nameof(CorruptedBanner),
            nameof(OceanBanner),
            nameof(JungleBanner)
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 200000;
        public override int Multiplyer => 5;
    }

    public class UndergroundJungleBanner : BannerItem
    {
        public override string ShowName => "Underground Jungle";
        public override short[] BannerList => new short[] {
            ItemID.ManEaterBanner,
            ItemID.SpikedJungleSlimeBanner,
            ItemID.HornetBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] {
            ItemID.DoctorBonesBanner,
            ItemID.LacBeetleBanner
        };
        public override int Price => 100000;
        public override int Multiplyer => 5;
    }
    public class UndergroundDesertBanner : BannerItem
    {
        public override string ShowName => "Underground Desert";
        public override short[] BannerList => new short[] {
            ItemID.WalkingAntlionBanner,
            ItemID.FlyingAntlionBanner,
            ItemID.TombCrawlerBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 50000;
        public override int Multiplyer => 3;
    }
    public class GlowingMushroomBanner : BannerItem
    {
        public override string ShowName => "Glowing Mushroom";
        public override short[] BannerList => new short[] {
            ItemID.SporeZombieBanner,
            ItemID.MushiLadybugBanner,
            ItemID.AnomuraFungusBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 30000;
        public override int Multiplyer => 3;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] {
            ItemID.CochinealBeetleBanner,
            ItemID.CrawdadBanner,
            ItemID.GiantShellyBanner,
            ItemID.WormBanner,
            ItemID.NypmhBanner,
            ItemID.SalamanderBanner,
            ItemID.TimBanner,
            ItemID.UndeadMinerBanner
        };
        public override int Price => 100000;
        public override int Multiplyer => 5;
    }
    public class UndergroundBanner : BannerItem
    {
        public override string ShowName => "Underground";
        public override short[] BannerList => new short[] { };
        public override string[] BannerItemNames => new string[] {
            nameof(CavernBanner),
            nameof(GlowingMushroomBanner),
            nameof(UndergroundDesertBanner),
            nameof(UndergroundJungleBanner)
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 200000;
        public override int Multiplyer => 5;
    }
    public class BloodMoonBanner : BannerItem
    {
        public override string ShowName => "Blood Moon";
        public override short[] BannerList => new short[] {
            ItemID.BloodZombieBanner,
            ItemID.DripplerBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { 
            ItemID.CorruptBunnyBanner,
            ItemID.CorruptGoldfishBanner,
            ItemID.CorruptPenguinBanner,
            ItemID.TheGroomBanner
        };
        public override int Price => 30000;
        public override int Multiplyer => 3;
    }
    public class AdvancedBanner : BannerItem
    {
        public override string ShowName => "Advanced";
        public override short[] BannerList => new short[] { 
            ItemID.HarpyBanner
        };
        public override string[] BannerItemNames => new string[] {
            nameof(ModerateBanner),
            nameof(UndergroundBanner),
            nameof(BloodMoonBanner)
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 300000;
        public override int Multiplyer => 8;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 50000;
        public override int Multiplyer => 5;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 50000;
        public override int Multiplyer => 5;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 80000;
        public override int Multiplyer => 5;
    }
    public class ProfessionalBanner : BannerItem
    {
        public override string ShowName => "Professional";
        public override short[] BannerList => new short[] {
            ItemID.MeteorHeadBanner
        };
        public override string[] BannerItemNames => new string[] {
            nameof(AdvancedBanner),
            nameof(DungeonBanner),
            nameof(GoblinArmyBanner),
            nameof(UnderworldBanner)
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 500000;
        public override int Multiplyer => 8;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 30000;
        public override int Multiplyer => 5;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 10000;
        public override int Multiplyer => 3;
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
        public override string[] BannerItemNames => new string[] { 
            nameof(HardmodeCavernBanner)
        };
        public override short[] AdditionalBanners => new short[] { 
            ItemID.RuneWizardBanner,
            ItemID.AnglerFishBanner,
            ItemID.MedusaBanner,
            ItemID.PigronBanner,
            ItemID.MothBanner
        };
        public override int Price => 50000;
        public override int Multiplyer => 5;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] {
            ItemID.SandsharkCorruptBanner,
        };
        public override int Price => 100000;
        public override int Multiplyer => 3;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] {
            ItemID.SandsharkCrimsonBanner,
            ItemID.BloodJellyBanner,
            ItemID.BloodFeederBanner
        };
        public override int Price => 30000;
        public override int Multiplyer => 3;
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
            ItemID.IlluminantBatBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] {
            ItemID.SandsharkHallowedBanner,
            ItemID.RainbowSlimeBanner
        };
        public override int Price => 30000;
        public override int Multiplyer => 5;
    }
    public class MasterBanner : BannerItem
    {
        public override string ShowName => "Master";
        public override short[] BannerList => new short[] {
            ItemID.ClownBanner,
            ItemID.GoblinSummonerBanner
        };
        public override string[] BannerItemNames => new string[] {
            nameof(ProfessionalBanner),
            nameof(HardmodeSurfaceBanner),
            nameof(HardmodeUndergroundBanner),
            WorldGen.crimson ? nameof(HardmodeCrimsonBanner) : nameof(HardmodeCorruptedBanner),
            nameof(HallowBanner),
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 800000;
        public override int Multiplyer => 8;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 150000;
        public override int Multiplyer => 5;
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
        public override string[] BannerItemNames => new string[] {
            nameof(MasterBanner),
            WorldGen.crimson ? nameof(CorruptedBanner) : nameof(CrimsonBanner),
            WorldGen.crimson ? nameof(HardmodeCorruptedBanner) : nameof(HardmodeCrimsonBanner),
            nameof(PirateBanner)
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 1000000;
        public override int Multiplyer => 8;
    }

    public class TempleBanner : BannerItem
    {
        public override string ShowName => "Temple";
        public override short[] BannerList => new short[] {
            ItemID.FlyingSnakeBanner,
            ItemID.LihzahrdBanner
        };
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 100000;
        public override int Multiplyer => 3;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 200000;
        public override int Multiplyer => 5;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 300000;
        public override int Multiplyer => 5;
    }
    public class ExceptionalBanner : BannerItem
    {
        public override string ShowName => "Exceptional";
        public override short[] BannerList => new short[] { };
        public override string[] BannerItemNames => new string[] {
            nameof(UltraBanner),
            nameof(TempleBanner),
            nameof(DungeonBanner),
            nameof(SolarEclipseBanner)
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 1500000;
        public override int Multiplyer => 8;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 300000;
        public override int Multiplyer => 5;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 200000;
        public override int Multiplyer => 5;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 300000;
        public override int Multiplyer => 5;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 100000;
        public override int Multiplyer => 3;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 100000;
        public override int Multiplyer => 3;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 100000;
        public override int Multiplyer => 3;
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
        public override string[] BannerItemNames => new string[] { };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 100000;
        public override int Multiplyer => 3;
    }
    public class LunarBanner : BannerItem
    {
        public override string ShowName => "FrostMoon";
        public override short[] BannerList => new short[] { };
        public override string[] BannerItemNames => new string[] { 
            nameof(SolarBanner),
            nameof(VortexBanner),
            nameof(StardustBanner),
            nameof(NebulaBanner)
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 500000;
        public override int Multiplyer => 5;
    }
    public class TheBanner : BannerItem
    {
        public override string ShowName => "The";
        public override short[] BannerList => new short[] { };
        public override string[] BannerItemNames => new string[] {
            nameof(ExceptionalBanner),
            nameof(MartianBanner),
            nameof(PumpkinMoonBanner),
            nameof(FrostMoonBanner),
            nameof(LunarBanner)
        };
        public override short[] AdditionalBanners => new short[] { };
        public override int Price => 2000000;
        public override int Multiplyer => 8;
    }
}
