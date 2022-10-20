using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Items
{
    public abstract class CalamityModBannerItem : ModBannerItem { public override string ModSource => "CalamityMod"; }

    public class CalamityPrehardmodeBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Orange;
    }
    public class CrawlerBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Blue;
    }
    public class SulphurousBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Orange;
    }
    public class SmallAbyssBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Orange;
    }
    public class BrimstoneBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Orange;
    }
    public class SunkenBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Green;
    }
    public class CalamityBeginnerBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Green;
        public override string[] Groups => new[]{ "UltimateBannerMerging:CalamityBlightSlimeBanner" };
        public override int[] GroupItems => new[]
        {
            ModContent.Find<ModItem>("CalamityMod", "CrimulanBlightSlimeBanner").Type,
            ModContent.Find<ModItem>("CalamityMod", "EbonianBlightSlimeBanner").Type
        };
    }
    public class WulfrumBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Blue;
    }
    public class AstralBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.LightRed;
    }
    public class PlagueBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Lime;
    }
    public class MediumAbyssBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Pink;
    }
    public class FullSulphurousBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.LightRed;
    }
    public class CryoBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.LightRed;
    }
    public class AcidRainBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Orange;
    }
    public class CalamityHardmodeBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Pink;
    }
    public class CalamitySuperHardmodeBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Cyan;
    }
    public class LargeAbyssBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Cyan;
    }
    public class FullAcidRainBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Pink;
    }
    public class TheCalamityBanner : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Purple;
    }

    public class CalamityPrehardmodeTrophy : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Orange;
        public override string[] Groups => new[] { "UltimateBannerMerging:CalamityEvilBiomeBossTrophy" };
        public override int[] GroupItems => new[]
        {
            ModContent.Find<ModItem>("CalamityMod", "HiveMindTrophy").Type,
            ModContent.Find<ModItem>("CalamityMod", "PerforatorTrophy").Type
        };
    }
    public class CalamityHardmodeTrophy : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Pink;
    }
    public class CalamitySuperHardmodeTrophy : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Cyan;
    }
    public class CalamityProfanedTrophy : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Yellow;
    }
    public class CalamityDevouringTrophy : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Cyan;
    }
    public class CalamityImmaculateTrophy : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Red;
    }
    public class TheCalamityTrophy : CalamityModBannerItem
    {
        public override int RarityID => ItemRarityID.Purple;
    }

}
