using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

#pragma warning disable 649

namespace UltimateBannerMerging
{
    [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.Name")]
    internal class BannerConfig : ModConfig
    {
        [Range(1, 100)]
        [DefaultValue(18)]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.InvulnerabilityCap.Label")]
        [Tooltip("$Mods.UltimateBannerMerging.Config.BannerConfig.InvulnerabilityCap.Tooltip")]
        public int InvulnerabilityCap;
        [Range(1, 100)]
        [DefaultValue(18)]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.BossInvulnerabilityCap.Label")]
        [Tooltip("$Mods.UltimateBannerMerging.Config.BannerConfig.BossInvulnerabilityCap.Tooltip")]
        public int BossInvulnerabilityCap;
        [Range(1f, 100f)]
        [DefaultValue("4")]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.MaxDamageIncrease.Label")]
        public int MaxDamageIncrease;
        [Range(1f, 100f)]
        [DefaultValue("4")]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.MaxBossDamageIncrease.Label")]
        public int MaxBossDamageIncrease;
        [Range(1f, 100f)]
        [DefaultValue("5")]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.MaxLootMultiplier.Label")]
        public int MaxLootMultiplier;
        [Range(1f, 100f)]
        [DefaultValue("5")]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.MaxBossLootMultiplier.Label")]
        public int MaxBossLootMultiplier;

        [DefaultValue("true")]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.Piggy.Label")]
        [Tooltip("$Mods.UltimateBannerMerging.Config.BannerConfig.Piggy.Tooltip")]
        public bool Piggy;
        [DefaultValue("true")]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.Safe.Label")]
        [Tooltip("$Mods.UltimateBannerMerging.Config.BannerConfig.Safe.Tooltip")]
        public bool Safe;
        [DefaultValue("true")]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.Forge.Label")]
        [Tooltip("$Mods.UltimateBannerMerging.Config.BannerConfig.Forge.Tooltip")]
        public bool Forge;
        [DefaultValue("true")]
        [Label("$Mods.UltimateBannerMerging.Config.BannerConfig.Vault.Label")]
        [Tooltip("$Mods.UltimateBannerMerging.Config.BannerConfig.Vault.Tooltip")]
        public bool Vault;

        [JsonIgnore]
        public Dictionary<string, ItemInfo> BannerStats => new()
        {
            { "ForestBanner",                 new() { Price =   5000, Multiplyer = 3.0f } },
            { "RainBanner",                   new() { Price =   5000, Multiplyer = 3.0f } },
            { "DesertBanner",                 new() { Price =   5000, Multiplyer = 3.0f } },
            { "SnowBanner",                   new() { Price =   5000, Multiplyer = 3.0f } },
            { "BasicBanner",                  new() { Price =  10000, Multiplyer = 2.0f } },//6
            { "OceanBanner",                  new() { Price =   5000, Multiplyer = 3.0f } },
            { "JungleBanner",                 new() { Price =  10000, Multiplyer = 3.0f } },
            { "CorruptedBanner",              new() { Price =  10000, Multiplyer = 3.0f } },
            { "CrimsonBanner",                new() { Price =  10000, Multiplyer = 3.0f } },
            { "ModerateBanner",               new() { Price =  30000, Multiplyer = 2.0f } },//12 6
            { "UndergroundJungleBanner",      new() { Price =  10000, Multiplyer = 3.0f } },
            { "UndergroundDesertBanner",      new() { Price =  10000, Multiplyer = 3.0f } },
            { "GlowingMushroomBanner",        new() { Price =  10000, Multiplyer = 3.0f } },
            { "CavernBanner",                 new() { Price =  10000, Multiplyer = 3.0f } },
            { "UndergroundBanner",            new() { Price =  20000, Multiplyer = 1.5f } },//4.5
            { "BloodMoonBanner",              new() { Price =  10000, Multiplyer = 3.0f } },
            { "AdvancedBanner",               new() { Price =  50000, Multiplyer = 2.0f } },//24 12 9 6
            { "DungeonBanner",                new() { Price =  20000, Multiplyer = 3.0f } },
            { "GoblinArmyBanner",             new() { Price =  20000, Multiplyer = 3.0f } },
            { "OldArmyBanner",                new() { Price =  20000, Multiplyer = 3.0f } },
            { "UnderworldBanner",             new() { Price =  20000, Multiplyer = 3.0f } },
            { "ProfessionalBanner",           new() { Price =  80000, Multiplyer = 1.5f } },//36 18 13.5 9 4.5
            { "HardmodeSurfaceBanner",        new() { Price =  30000, Multiplyer = 3.0f } },
            { "HardmodeCavernBanner",         new() { Price =  30000, Multiplyer = 1.0f } },
            { "HardmodeUndergroundBanner",    new() { Price =  30000, Multiplyer = 3.0f } },
            { "HardmodeCorruptedBanner",      new() { Price =  30000, Multiplyer = 3.0f } },
            { "HardmodeCrimsonBanner",        new() { Price =  30000, Multiplyer = 3.0f } },
            { "HallowBanner",                 new() { Price =  30000, Multiplyer = 3.0f } },
            { "MasterBanner",                 new() { Price = 100000, Multiplyer = 2.0f } },//72 36 27 18 9 6
            { "PirateBanner",                 new() { Price =  50000, Multiplyer = 3.0f } },
            { "UltraBanner",                  new() { Price = 120000, Multiplyer = 2.0f } },//144 72 54 36 18 12 6
            { "TempleBanner",                 new() { Price =  50000, Multiplyer = 3.0f } },
            { "HardmodeDungeonBanner",        new() { Price =  50000, Multiplyer = 3.0f } },
            { "SolarEclipseBanner",           new() { Price =  50000, Multiplyer = 3.0f } },
            { "ExceptionalBanner",            new() { Price = 200000, Multiplyer = 1.5f } },//216 108 81 54 27 18 9 4.5
            { "MartianBanner",                new() { Price = 100000, Multiplyer = 3.0f } },
            { "OldArmyHardmodeBanner",        new() { Price = 100000, Multiplyer = 3.0f } },
            { "PumpkinMoonBanner",            new() { Price = 100000, Multiplyer = 3.0f } },
            { "FrostMoonBanner",              new() { Price = 100000, Multiplyer = 3.0f } },
            { "VortexBanner",                 new() { Price = 100000, Multiplyer = 3.0f } },
            { "StardustBanner",               new() { Price = 100000, Multiplyer = 3.0f } },
            { "NebulaBanner",                 new() { Price = 100000, Multiplyer = 3.0f } },
            { "SolarBanner",                  new() { Price = 100000, Multiplyer = 3.0f } },
            { "LunarBanner",                  new() { Price = 400000, Multiplyer = 3.0f } },
            { "TheBanner",                    new() { Price =1000000, Multiplyer = 18.0f} },

            { "HorrorTrophy",                 new() { Price =   5000, Multiplyer = 3.0f } }, // 3
            { "PreHardmodeTrophy",            new() { Price =  10000, Multiplyer = 3.0f } }, // 9 3
            { "MechanicsTrophy",              new() { Price =  25000, Multiplyer = 3.0f } }, // 3
            { "AncientTrophy",                new() { Price =  50000, Multiplyer = 3.0f } }, // 3
            { "MoonTrophy",                   new() { Price = 100000, Multiplyer = 3.0f } }, // 3
            { "EventsTrophy",                 new() { Price = 250000, Multiplyer = 6.0f } }, // 18 6
            { "TheTrophy",                    new() { Price =1000000, Multiplyer = 18.0f } }, // 18 9
            
            { "WulfrumBanner",                new() { Price =    5000, Multiplyer = 3.0f } },
            { "CrawlerBanner",                new() { Price =   10000, Multiplyer = 3.0f } },
            { "SulphurousBanner",             new() { Price =   10000, Multiplyer = 3.0f } },
            { "SunkenBanner",                 new() { Price =   20000, Multiplyer = 3.0f } },
            { "CalamityBeginnerBanner",       new() { Price =   50000, Multiplyer = 3.0f } },
            { "SmallAbyssBanner",             new() { Price =   30000, Multiplyer = 3.0f } },
            { "BrimstoneBanner",              new() { Price =   20000, Multiplyer = 3.0f } },
            { "CalamityPrehardmodeBanner",    new() { Price =  100000, Multiplyer = 6.0f } },
            { "AstralBanner",                 new() { Price =   70000, Multiplyer = 3.0f } },
            { "PlagueBanner",                 new() { Price =   60000, Multiplyer = 3.0f } },
            { "MediumAbyssBanner",            new() { Price =  100000, Multiplyer = 6.0f } },
            { "FullSulphurousBanner",         new() { Price =   90000, Multiplyer = 3.0f } },
            { "CryoBanner",                   new() { Price =   60000, Multiplyer = 3.0f } },
            { "AcidRainBanner",               new() { Price =   60000, Multiplyer = 3.0f } },
            { "CalamityHardmodeBanner",       new() { Price =  200000, Multiplyer = 3.0f } },
            { "CalamitySuperHardmodeBanner",  new() { Price = 1000000, Multiplyer = 3.0f } },
            { "LargeAbyssBanner",             new() { Price =  500000, Multiplyer = 6.0f } },
            { "FullAcidRainBanner",           new() { Price =   80000, Multiplyer = 3.0f } },
            { "TheCalamityBanner",            new() { Price = 5000000, Multiplyer = 18.0f } },

            { "CalamityPrehardmodeTrophy",    new() { Price =   10000, Multiplyer = 3.0f } },
            { "CalamityHardmodeTrophy",       new() { Price =    1000, Multiplyer = 3.0f } },
            { "CalamitySuperHardmodeTrophy",  new() { Price =10000000, Multiplyer = 3.0f } },
            { "CalamityProfanedTrophy",       new() { Price = 5000000, Multiplyer = 3.0f } },
            { "CalamityDevouringTrophy",      new() { Price =40000000, Multiplyer = 3.0f } },
            { "CalamityImmaculateTrophy",     new() { Price =80000000, Multiplyer = 6.0f } },
            { "TheCalamityTrophy",            new() { Price =100000000, Multiplyer = 18.0f } },

        };

        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
    internal struct ItemInfo
    {
        public int Price { get; set; }
        public float Multiplyer { get; set; }
    }
}
#pragma warning restore 649
