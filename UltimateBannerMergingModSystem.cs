using Terraria.Localization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging;

public class UltimateBannerMergingModSystem : ModSystem
{
    public override void AddRecipeGroups()
    {
        RecipeGroup.RegisterGroup("UltimateBannerMerging:EvilBiomeMeat", new(
            () => Language.GetTextValue("Mods.UltimateBannerMerging.IngredientGroups.EvilBiomeMeat"),
            ItemID.RottenChunk,
            ItemID.TissueSample));

        RecipeGroup.RegisterGroup("UltimateBannerMerging:EvilBiomeBanner", new(
            () => Language.GetTextValue("Mods.UltimateBannerMerging.IngredientGroups.EvilBiomeBanner"),
            ModContent.Find<ModItem>("UltimateBannerMerging", "CrimsonBanner").Type,
            ModContent.Find<ModItem>("UltimateBannerMerging", "CorruptedBanner").Type));

        RecipeGroup.RegisterGroup("UltimateBannerMerging:HardmodeEvilBiomeBanner", new(
            () => Language.GetTextValue("Mods.UltimateBannerMerging.IngredientGroups.HardmodeEvilBiomeBanner"),
            ModContent.Find<ModItem>("UltimateBannerMerging", "HardmodeCrimsonBanner").Type,
            ModContent.Find<ModItem>("UltimateBannerMerging", "HardmodeCorruptedBanner").Type));

        RecipeGroup.RegisterGroup("UltimateBannerMerging:EvilBiomeTrophy", new(
            () => Language.GetTextValue("Mods.UltimateBannerMerging.IngredientGroups.EvilBiomeTrophy"),
            ItemID.BrainofCthulhuTrophy,
            ItemID.EaterofWorldsTrophy));

        if (ModLoader.HasMod("CalamityMod"))
        {
            RecipeGroup.RegisterGroup("UltimateBannerMerging:CalamityBlightSlimeBanner", new(() => Language.GetTextValue("Mods.UltimateBannerMerging.IngredientGroups.CalamityBlightSlimeBanner"),
                ModContent.Find<ModItem>("CalamityMod", "EbonianBlightSlimeBanner").Type,
                ModContent.Find<ModItem>("CalamityMod", "CrimulanBlightSlimeBanner").Type));

            RecipeGroup.RegisterGroup("UltimateBannerMerging:CalamityEvilBiomeBossTrophy", new(() => Language.GetTextValue("Mods.UltimateBannerMerging.IngredientGroups.CalamityEvilBiomeBossTrophy"),
                ModContent.Find<ModItem>("CalamityMod", "HiveMindTrophy").Type,
                ModContent.Find<ModItem>("CalamityMod", "PerforatorTrophy").Type));
        }
    }
}