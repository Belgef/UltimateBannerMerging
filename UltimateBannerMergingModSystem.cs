using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging;

public class UltimateBannerMergingModSystem : ModSystem
{
    public override void AddRecipeGroups()
    {
        RecipeGroup.RegisterGroup("UltimateBannerMerging:EvilBiomeBanner", new(() => "Crimson or Corrupted Banner",
            ModContent.Find<ModItem>("UltimateBannerMerging", "CrimsonBanner").Type,
            ModContent.Find<ModItem>("UltimateBannerMerging", "CorruptedBanner").Type));
        RecipeGroup.RegisterGroup("UltimateBannerMerging:HardmodeEvilBiomeBanner", new(() => "Harmode Crimson or Corrupted Banner",
            ModContent.Find<ModItem>("UltimateBannerMerging", "HardmodeCrimsonBanner").Type,
            ModContent.Find<ModItem>("UltimateBannerMerging", "HardmodeCorruptedBanner").Type));
        RecipeGroup.RegisterGroup("UltimateBannerMerging:EvilBiomeTrophy", new(() => "Brain of Cthulhu or Eater of Worlds Trophy",
            ItemID.BrainofCthulhuTrophy,
            ItemID.EaterofWorldsTrophy));

        if (ModLoader.HasMod("CalamityMod"))
        {
            RecipeGroup.RegisterGroup("UltimateBannerMerging:CalamityBlightSlimeBanner", new(() => "Ebonian or Crimulan Blight Slime Banner",
                ModContent.Find<ModItem>("CalamityMod", "EbonianBlightSlimeBanner").Type,
                ModContent.Find<ModItem>("CalamityMod", "CrimulanBlightSlimeBanner").Type));
            RecipeGroup.RegisterGroup("UltimateBannerMerging:CalamityEvilBiomeBossTrophy", new(() => "The Hive Mind or Perforator Trophy",
                ModContent.Find<ModItem>("CalamityMod", "HiveMindTrophy").Type,
                ModContent.Find<ModItem>("CalamityMod", "PerforatorTrophy").Type));
        }
    }
}