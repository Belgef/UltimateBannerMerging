using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Items
{
    public abstract class CalamityModBannerItem : ModBannerItem { public override string ModSource => "CalamityMod"; }

    public class CalamityPrehardmodeBanner : CalamityModBannerItem { public override string Name => "CalamityPrehardmodeBanner";  }
    public class CrawlerBanner : CalamityModBannerItem { public override string Name => "CrawlerBanner"; }
    public class SulphurousBanner : CalamityModBannerItem { public override string Name => "SulphurousBanner"; }
    public class SmallAbyssBanner : CalamityModBannerItem { public override string Name => "SmallAbyssBanner"; }
    public class BrimstoneBanner : CalamityModBannerItem { public override string Name => "BrimstoneBanner"; }
    public class SunkenBanner : CalamityModBannerItem { public override string Name => "SunkenBanner"; }
    public class CalamityBeginnerBanner : CalamityModBannerItem 
    { 
        public override string Name => "CalamityBeginnerBanner";
        public override string[] Groups => new[]{ "UltimateBannerMerging:CalamityBlightSlimeBanner" };
        public override int[] GroupItems => new[]
        {
            ModContent.Find<ModItem>("CalamityMod", "CrimulanBlightSlimeBanner").Type,
            ModContent.Find<ModItem>("CalamityMod", "EbonianBlightSlimeBanner").Type
        };
    }
    public class WulfrumBanner : CalamityModBannerItem { public override string Name => "WulfrumBanner"; }
    public class AstralBanner : CalamityModBannerItem { public override string Name => "AstralBanner"; }
    public class PlagueBanner : CalamityModBannerItem { public override string Name => "PlagueBanner"; }
    public class MediumAbyssBanner : CalamityModBannerItem { public override string Name => "MediumAbyssBanner"; }
    public class FullSulphurousBanner : CalamityModBannerItem { public override string Name => "FullSulphurousBanner"; }
    public class CryoBanner : CalamityModBannerItem { public override string Name => "CryoBanner"; }
    public class AcidRainBanner : CalamityModBannerItem { public override string Name => "AcidRainBanner"; }
    public class CalamityHardmodeBanner : CalamityModBannerItem { public override string Name => "CalamityHardmodeBanner"; }
    public class CalamitySuperHardmodeBanner : CalamityModBannerItem { public override string Name => "CalamitySuperHardmodeBanner"; }
    public class LargeAbyssBanner : CalamityModBannerItem { public override string Name => "LargeAbyssBanner"; }
    public class FullAcidRainBanner : CalamityModBannerItem { public override string Name => "FullAcidRainBanner"; }
    public class TheCalamityBanner : CalamityModBannerItem { public override string Name => "TheCalamityBanner"; }

    public class CalamityPrehardmodeTrophy : CalamityModBannerItem 
    { 
        public override string Name => "CalamityPrehardmodeTrophy";
        public override string[] Groups => new[] { "UltimateBannerMerging:CalamityEvilBiomeBossTrophy" };
        public override int[] GroupItems => new[]
        {
            ModContent.Find<ModItem>("CalamityMod", "HiveMindTrophy").Type,
            ModContent.Find<ModItem>("CalamityMod", "PerforatorTrophy").Type
        };
    }
    public class CalamityHardmodeTrophy : CalamityModBannerItem { public override string Name => "CalamityHardmodeTrophy"; }
    public class CalamitySuperHardmodeTrophy : CalamityModBannerItem { public override string Name => "CalamitySuperHardmodeTrophy"; }
    public class CalamityProfanedTrophy : CalamityModBannerItem { public override string Name => "CalamityProfanedTrophy"; }
    public class CalamityDevouringTrophy : CalamityModBannerItem { public override string Name => "CalamityDevouringTrophy"; }
    public class CalamityImmaculateTrophy : CalamityModBannerItem { public override string Name => "CalamityImmaculateTrophy"; }
    public class TheCalamityTrophy : CalamityModBannerItem { public override string Name => "TheCalamityTrophy"; }

}
